//最小公倍数
function lcm(a) {
    var g = (n, m) => m ? g(m, n % m) : n;
    var l = (n, m) => n * m / g(n, m);
    var ans = a[0];
    for (var i = 1; i < a.length; i++) {
        ans = l(ans, a[i]);
    }
    return ans;
} 

//最大公約数
function gcd(a) {
    var f = (a, b) => b ? f(b, a % b) : a;
    var ans = a[0];
    for (var i = 1; i < a.length; i++) {
        ans = f(ans, a[i]); 
    }
    return ans;
}
