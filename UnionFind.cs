public class UnionFind {
    public int[] rnk, par;
    public UnionFind(int n) {
        this.rnk = new int[n];
        this.par = new int[n];
        for (var i = 0; i < n; i++) this.par[i] = i;
    }
    public int root(int x) {
        if (this.par[x] == x) return x;
        return this.par[x] = this.root(this.par[x]);
    }
    public bool unite(int x, int y) {
        var rx = this.root(x);
        var ry = this.root(y);
        if (rx == ry) return false;

        if (this.rnk[rx] < this.rnk[ry]) {
            this.par[rx] = ry;
        } else {
            this.par[ry] = rx;
            if (this.rnk[rx] == this.rnk[ry]) this.rnk[rx] += 1;
        }
        return true;
    }
    public bool same(int x, int y) {
        var rx = this.root(x);
        var ry = this.root(y);
        return rx == ry;
    }
    public int size(int x) {
        return this.rnk[this.root(x)];
    }
    public int find(int x) { return this.root(x); }
    public void union(int x, int y) { this.unite(x, y); }
}
