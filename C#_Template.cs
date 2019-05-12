/*
Convert.ToString(value, n); //valueをn進数に変換
int.MAX_VALUE
Math.Ceiling(n); //小数点以下を切り上げ
Math.Floor(n); //小数点以下を切り捨て
Math.Round(n); //小数点以下を四捨五入
Math.pow(n, m); //n の m 乗。
----------------------------------------------------------------------
var char = string.charAt(n);
var subString = string.substring(from [, to]); //to-1
var subString = string.substr(from [, len]);
var subString = string.slice(from [, to]); //to-1：マイナスは末尾から
var newbString = string.trim();
var array = string.split([sep [, limit]]);
var newbString = string.concat(string2);
var newbString = string.replace(regexp, newString);
var newbString = string.toUpperCase();
var newbString = string.toLowerCase();
var n = string.indexOf(key [, from]); //見つからない場合は -1
var n = string.search(regexp); //見つからない場合は -1
var n = string.lastIndexOf(key [, from]); //見つからない場合は -1
var newbString = string.match(regexp); //マッチしなかった時はnullを返す
----------------------------------------------------------------------
array.forEach(function(value, index, array) {});
var newArray = array.map(function(value) { return value; });
array.sort((a, b) => a - b); //asc
array.sort(function(a, b) { return b - a; }); //desc
var ret = array.reduce((ac, value, index, array) => ac + value, 0);
using System.Linq; //Enumerable
int a = array.Max(); //using System.Linq;
int a = array.Min(); //using System.Linq;
int a = array.Sum(); //using System.Linq;
int a = array.Count(v => v > 5); //using System.Linq;
bool f = array.All(v => true); //all true
bool f = array.Any(v => true); //some true
var obj = array.Select((value, index) => new { index, value }); //map?
----------------------------------------------------------------------
var array = new Array(N).fill(0);
var array[][] = new int[Y][X]; //二次元配列
var top = array.shift(); //先頭を削除
var last = array.pop(); //最後を削除
array.push(e1, e2, ...); //最後に追加
array.unshift(e1, e2, ...); //先頭に追加
var newArray = array.slice(start [, end]); //startからend-1までの配列
var newArray = array.concat(array2, ...); //元のarrayは変更なし
var str = string.Join(", ", array); //文字連結
array.Reverse();
----------------------------------------------------------------------
public int func(int a, int b) { return a + b; }
Func<int, int, int> func = (a, b) => a + b;
Func<int, int, bool> func = (a, b) => a > b;
----------------------------------------------------------------------
for (var i = 0; i < N; i++) {}
for (var j = 0; j < N; j++) {}
for (var k = 0; k < N; k++) {}
for (var n = 0; n < N; n++) {}
for (var m = 0; m < M; m++) {}
for (var n = 1; n <= N; n++) {}
if () {}
if () {} else {}
if () {} else if () {} else {}
while (true) {}
foreach (type value of array) {}
----------------------------------------------------------------------
public class IntReverseComparer: IComparer {
    public int Compare(Object x, Object y) {
        return (int)y - (int)x;
    }
}
Array.Sort(array, new IntReverseComparer());
int[] array = {3, 1, 5, 4, 2};
Array.Sort(array);
Array.Reverse(array);
var array[][] = new int[Y][X];
var ch = string.ToCharArray(); //string->char[]
string.Join(", ", str)
Console.WriteLine("{0} {1}", a0, a1);
Console.Error.WriteLine("{0} {1}", a0, a1);

Console.WriteLine(
    1.Calc(x => x * 2)
        .Action(x => Console.WriteLine(x))
        .Repeat(4, x => x * x)
        .Action(x => Console.WriteLine(x))
);

 */
//#define LOCAL_ENVIRONMENT
using System;
using System.IO;
using System.Text;
class Program {
    static int __cnt = 0;
    static string __mark = "###";
    static void Main(string[] args) {
#if LOCAL_ENVIRONMENT
        StreamReader __sr = new StreamReader("stdin.txt");
        string __str = __sr.ReadToEnd();
        __sr.Close();
        int __index = __str.IndexOf(__mark, 0);
        while (__index != -1) {
            __index = __str.IndexOf(__mark, __index + __mark.Length);
            __cnt++;
        }
        if (__cnt > 0) {
            Console.WriteLine("Eenter test data no(1-{0})? ", __cnt);
            if (!int.TryParse(Console.ReadLine(), out __cnt)) __cnt = 1;
            Console.WriteLine("Select/Default test data: {0}", __cnt);
        }
        var stdin = new System.IO.StreamReader("stdin.txt");
        Console.SetIn(stdin);
#endif
        SimpleScanner sc = new SimpleScanner(__cnt);
        var a = sc.NextInt();
        int b = sc.NextInt(), c = sc.NextInt();
        var s = sc.NextString();
        Console.WriteLine("{0} {1}", a + b + c, s);
        int[][] x = sc.NextInt2Col(3);

        int[] array = { 3, 1, 5, 4, 2 };
        Array.Sort(array);
        Array.Reverse(array);
        Console.Error.WriteLine("max: {0}", array.Max());
        Console.Error.WriteLine("{0}", array.ToStringA(braces: "<>"));

        var t = Tuple.Create(0, 1, 2);
        Console.WriteLine("{0}: {1}", t.GetType().Name, t.ToString());

        Console.WriteLine(
            1.Action(v => Console.WriteLine(v))
                .Calc(v => v * 2)
                .Action(v => Console.WriteLine(v))
                .Repeat(4, w => w * w)
                .Action(w => Console.WriteLine(w))
        );
        long ans = 0;
        Console.WriteLine(ans);
    } //Main

    //最大公約数
    static Func<int, int, int> Gcd = (a, b) => b != 0 ? Gcd(b, a % b) : a;
    //最小公倍数（gcd版）
    static Func<int, int, int> Lcm = (a, b) => a * b / Gcd(a, b);
    //順列
    static Func<int, int, int> Permutation = (n, r) => {
        var result = 1;
        for (var m = n; r > 0; m--, r--) result *= m;
        return result;
    };
    //組合せ
    static Func<int, int, int> Combination = (n, r) => {
        var result = Permutation(n, r);
        for (; r > 0; r--) result /= r;
        return result;
    };

/*
static Func<int> prime = (v) => {
    var a = v, i, r = [];
    for (var j = 2; j <= Math.floor(v / 2) && 1 < a; j += 1 + (j & 1)) {
        for (i = 0; a % j == 0; i++) a = Math.floor(a / j);
        if (i) r.push([j, i]);
    }
    if (r.length == 0) r.push([v, 1]);
    return r;
} //30=>2^1*3^1*5^1=>[[2,1],[3,1],[5,1]]
*/
    public class SimpleScanner {
        private int cnt;
        private string[] items;
        public SimpleScanner(int cnt = 0) {
            this.cnt = 0;
            var sb = new StringBuilder();
            var s = Console.ReadLine();
            while (s != null) {
                sb.Append(s + " ");
                s = Console.ReadLine();
            }
            this.items = sb.ToString().Split(' ');
#if LOCAL_ENVIRONMENT
            if (cnt > 0) {
                int index = Array.IndexOf(this.items, __mark + cnt.ToString());
                this.cnt = index + 1;
            }
            Console.Error.WriteLine("SimpleScanner.cnt: {0}", this.cnt);
            Console.Error.WriteLine("SimpleScanner.items: {0}" , this.items.ToStringA());
#endif
        }
        public void SetCnt(int n) { this.cnt = n; }
        public int NextInt() {
            return int.Parse(this.items[this.cnt++]);
        }
        public long NextLong() {
            return long.Parse(this.items[this.cnt++]);
        }
        public string NextString() {
            return this.items[this.cnt++];
        }
        public int[] NextIntArray(int n) {
            if (n < 1) throw new IndexOutOfRangeException("引数は1以上であること！");
            var result = new int[n];
            for (var i = 0; i < n; i++) result[i] = this.NextInt();
#if LOCAL_ENVIRONMENT
            Console.Error.WriteLine("{0}", result.ToStringA());
#endif
            return result;
        }
        public long[] NextLongArray(int n) {
            if (n < 1) throw new IndexOutOfRangeException("引数は1以上であること！");
            var result = new long[n];
            for (var i = 0; i < n; i++) result[i] = this.NextLong();
#if LOCAL_ENVIRONMENT
            Console.Error.WriteLine("{0}", result.ToStringA());
#endif
            return result;
        }
        public string[] NextStringArray(int n) {
            if (n < 1) throw new IndexOutOfRangeException("引数は1以上であること！");
            var result = new string[n];
            for (var i = 0; i < n; i++) result[i] = this.NextString();
#if LOCAL_ENVIRONMENT
            Console.Error.WriteLine("{0}", result.ToStringA());
#endif
            return result;
        }
        public int[][] NextInt2Col(int n) {
            const int M = 2;
            if (n < 1) throw new IndexOutOfRangeException("引数は1以上であること！");
            int[][] result = new int[M][] {
                new int[n],
                new int[n],
            };
            for (var i = 0; i < n; i++) {
                result[0][i] = this.NextInt();
                result[1][i] = this.NextInt();
            }
#if LOCAL_ENVIRONMENT
            Console.Error.WriteLine("NextInt2Col: [");
            for (var i = 0; i < M; i++)
                Console.Error.WriteLine("  {0},", result[i].ToStringA());
            Console.Error.WriteLine("]");
#endif
            return result;
        }
    }
}
static class Extensions {
    public static bool IsEven(this int value) {
        return value % 2 == 0;
    }
    public static bool IsOdd(this int value) {
        return value % 2 != 0;
    }
    public static string ToStringA<T>(this T[] array, string separator = ", ", string braces = "[]") {
        string bL = braces.Length > 0 ? braces[0].ToString() : "";
        string bR = braces.Length > 1 ? braces[1].ToString() : "";
        return bL + String.Join(separator, array) + bR;
    }
    public static T Max<T>(this T[] array) where T: IComparable {
        if(array.Length < 1) throw new IndexOutOfRangeException("要素は1つ以上であること！");
        T max = array[0];
        for(int i = 1; i < array.Length; i++) {
            max = max.CompareTo(array[i]) > 0 ? max : array[i];
        }
        return max;
    }
    public static T Min<T>(this T[] array) where T: IComparable {
        if(array.Length < 1) throw new IndexOutOfRangeException("要素は1つ以上であること！");
        T min = array[0];
        for(int i = 1; i < array.Length; i++) {
            min = min.CompareTo(array[i]) < 0 ? min : array[i];
        }
        return min;
    }
    public static T[] SortDesc<T>(this T[] array) {
        Array.Sort(array);
        Array.Reverse(array);
        return array;
    }
}
public static class ChainExtensions {
    // Calc :: T -> (T -> U) -> U
    public static U Calc<T, U>(this T a,  Func<T, U> f) { return f(a); }
    // Action :: T -> (T -> Void) -> T
    public static T Action<T>(this T a, Action<T> f) { f(a); return a; }
    // Action :: T -> (T -> U) -> T
    public static T Action<T, U>(this T a, Func<T, U> f) { f(a); return a; }
    // Repeat :: T -> int -> (T -> T) -> T
    public static T Repeat<T>(this T a, int n, Func<T, T> f)
    { return n > 0 ? f(a).Repeat(n - 1, f) : a; }
    
    // Left :: T -> (T -> U) -> T
    public static T Left<T, U>(this T a, Func<T, U> f) { f(a); return a; }
    // Right :: T -> (T -> U) -> T -> U
    public static Func<T, U> Right<T, U>(this T a, Func<T, U> f) { f(a); return f; }
    // All :: T -> (T -> U) -> (T, T -> U, U)
    public static Tuple<T, Func<T, U>, U> All<T, U>(this T a, Func<T, U> f)
    { return Tuple.Create(a, f, f(a)); }
}
