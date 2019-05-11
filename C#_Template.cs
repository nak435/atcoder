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
var xyArray = new Array(X).fill(0).map(() => new Array(Y).fill(0)); //二次元配列
var top = array.shift(); //先頭を削除
var last = array.pop(); //最後を削除
array.push(e1, e2, ...); //最後に追加
array.unshift(e1, e2, ...); //先頭に追加
var newArray = array.slice(start [, end]); //startからend-1までの配列
var newArray = array.concat(array2, ...); //元のarrayは変更なし
var str = array.join(','); //文字連結
array.reverse();
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
    1.Calc( x => x * 2)
        .Action( x => Console.WriteLine(x))
        .Repeat( 4, x => x * x)
        .Action( x => Console.WriteLine(x));
);

 */
// #define LOCAL_ENVIRONMENT
using System;
using System.Collections;
using System.Text;
class Program {
    static void Main(string[] args) {
#if LOCAL_ENVIRONMENT
        var stdin = new System.IO.StreamReader("stdin.txt");
        System.Console.SetIn(stdin);
#endif
        SimpleScanner sc = new SimpleScanner();
        var a = sc.NextInt();
        int b = sc.NextInt(), c = sc.NextInt();
        var s = sc.NextString();
        Console.WriteLine("{0} {1}", a + b + c, s);
        int[][] x = sc.NextInt2Col(3);

        int[] array = { 3, 1, 5, 4, 2 };
        Array.Sort(array);
        Array.Reverse(array);
        Console.Error.WriteLine("[{0}]", string.Join(", ", array));

    }

    public T Max<T>(params T[] nums) where T: IComparable {
        if(nums.Length < 1) throw new IndexOutOfRangeException("要素は1つ以上であること！");
        T max = nums[0];
        for(int i = 1; i < nums.Length; i++) {
            max = max.CompareTo(nums[i]) > 0 ? max : nums[i];
        }
        return max;
    }
    public T Min<T>(params T[] nums) where T: IComparable {
        if(nums.Length < 1) throw new IndexOutOfRangeException("要素は1つ以上であること！");
        T min = nums[0];
        for(int i = 1; i < nums.Length; i++) {
            min = min.CompareTo(nums[i]) < 0 ? min : nums[i];
        }
        return min;
    }

    public class SimpleScanner {
        private int cnt;
        private string[] items;
        public SimpleScanner() {
            this.cnt = 0;
            var sb = new StringBuilder();
            var s = Console.ReadLine();
            while (s != null) {
                sb.Append(s + " ");
                s = Console.ReadLine();
            }
            this.items = sb.ToString().Split(' ');
#if LOCAL_ENVIRONMENT
Console.Error.WriteLine("SimpleScanner.items: [{0}]" , string.Join(", ", this.items));
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
            Console.Error.WriteLine("[{0}]", string.Join(", ", result));
#endif
            return result;
        }
        public long[] NextLongArray(int n) {
            if (n < 1) throw new IndexOutOfRangeException("引数は1以上であること！");
            var result = new long[n];
            for (var i = 0; i < n; i++) result[i] = this.NextLong();
#if LOCAL_ENVIRONMENT
            Console.Error.WriteLine("[{0}]", string.Join(", ", result));
#endif
            return result;
        }
        public string[] NextStringArray(int n) {
            if (n < 1) throw new IndexOutOfRangeException("引数は1以上であること！");
            var result = new string[n];
            for (var i = 0; i < n; i++) result[i] = this.NextString();
#if LOCAL_ENVIRONMENT
            Console.Error.WriteLine("[{0}]", string.Join(", ", result));
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
                Console.Error.WriteLine("  [{0}],", string.Join(", ", result[i]));
            Console.Error.WriteLine("]");
#endif
            return result;
        }
    }
}

public static class ChainExtendMethoads {
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
