/*
String output = String.format("%s : %d", "joe", 35);
System.out.printf("My name is: %s%n", "joe");
System.err.printf("My name is: %s%n", "joe");

HashMap<String, String> hashmap = new HashMap<String, String>();//[1]
hashmap.put("apple", "りんご");//[2]
hashmap.get("apple"));

Arrays.stream(array).sorted(Comparator.naturalOrder()).toArray();
Arrays.sort(originalObject, Comparator.comparing(originalObject::keyItem); // 昇順
Arrays.sort(originalObject, Comparator.comparing(originalObject::keyItem).reversed()); // 降順
Comparator<Original> comparator = Comparator.comparing(Original::keyItem1).thenComparing(Original::keyItem2).reversed();
array.stream().sorted(comparator).forEach(a ->System.out.println(a));

int[][] XYArray = new int[Y][X];
Arrays.sort(array); // 昇順
Arrays.sort(array, Comparator.reverseOrder()); // 降順
Arrays.sort(array, (a, b) -> { return b - a; }); // 降順

int[] newArray = Arrays.copyOf(array, array.length);
Arrays.fill(array, 0);
Arrays.stream(array).sum();
for (int n = 0; n < N; n++) { }
string.charAt(n)
cnt[S.charAt(n) - 'a']++;
String.valueOf(string.charAt(n)) //char -> String
char[] ch = string.toCharArray(); //String -> char[]
String[] ch = string.split(""); //String -> string[0]

*/
//package xxx;
import java.util.*;
public class Java_Template {
    static int dfs(int i, int r, int sum) {  //dfs(0, K, 0);
        if (r == 0) {
            int cnt = 0;
            while (sum > 0) {
                int s = sum % 10;
                if (s >= 5) cnt += (s - 5) + 1;
                else cnt += s;
                sum /= 10;
            }
            return cnt;
        }
        if (i == N) return Integer.MAX_VALUE;

        int use    = dfs(i + 1, r - 1, sum + A[i]);
        int notuse = dfs(i + 1, r    , sum);
        return Math.min(use, notuse);
    }

    static int lowerBound(int a[], int v) {
        int l = 0, r = a.length - 1;
        while (r - l >= 0) {
            int c = (l + r) / 2;
            if (v <= a[c]) {
                r = c - 1;
            } else {
                l = c + 1;
            }
        }
        return l;
    }
    static void sortDesc(int[] array) {
        Arrays.sort(array);
        int[] temp = Arrays.copyOf(array, array.length);
        for (int n = 0; n < array.length; n++) { array[n] = temp[array.length - n - 1]; }
    }
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int a = sc.nextInt();
        int b = sc.nextInt();
        int c = sc.nextInt();
        String s = sc.next();
        System.out.println((a + b + c) + " " + s);
        sc.close();

        int[] array = {1, 2, 3, 4, 5};
        sortDesc(array);
        System.out.println(Arrays.toString(array));
    }
}
class Item {
    int n, x, y;
    Item(int n, int y, int x) {
        this.n = n;
        this.x = x;
        this.y = y;
    }
}
class Queue {
    Deque<Item> Q;
    Queue() {
        Q = new ArrayDeque<>();
    }
    int add(int n, int y, int x) {
        Q.add(new Item(n, y, x));
        return n;
    }
    boolean isEmpty() { return Q.isEmpty(); }
    Item poll() { return Q.poll(); }
}
