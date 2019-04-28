//最大公約数
const gcd = (a, b) => b ? gcd(b, a % b) : a;
//最小公倍数（gcd版）
const lcm = (a, b) => a * b / gcd(a, b);

//最大公約数（配列版）
function gcd(v) {
    const g = (a, b) => b ? g(b, a % b) : a;
    let r = v[0];
    for (let i = 1; i < v.length; i++) {
        r = g(r, v[i]); 
    }
    return r;
}

//最小公倍数（配列版）
function lcm(v) {
    const g = (a, b) => b ? g(b, a % b) : a;
    const l = (a, b) => a * b / g(a, b);
    let r = v[0];
    for (let i = 1; i < v.length; i++) {
        r = l(r, v[i]);
    }
    return r;
} 

//素因数分解
function prime(v) {
    let a = v, i, r = [];
    for (let j = 2; j <= Math.floor(v / 2) && 1 < a; j += 1 + (j & 1)) {
        for (i = 0; a % j == 0; i++) a = Math.floor(a / j);
        if (i) r.push([j, i]);
    }
    if (r.length == 0) r.push([v, 1]);
    return r;
} //30=>2^1*3^1*5^1=>[[2,1],[3,1],[5,1]]
