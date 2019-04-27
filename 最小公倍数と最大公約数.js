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
