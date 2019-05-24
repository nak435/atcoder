    public class UnionFind {
        public int[] rank, par, size;
        public UnionFind(int n) {
            this.rank = new int[n];
            this.par = new int[n];
            this.size = new int[n];
            for (var i = 0; i < n; i++) {
                this.par[i] = i;
                this.size[i] = 1;
            }
        }
        public int find(int x) {
            if (this.par[x] == x) return x;
            return this.par[x] = this.find(this.par[x]);
        }
        public bool union(int x, int y) {
            var rx = this.root(x);
            var ry = this.root(y);
            if (rx == ry) return false;

            if (this.rank[rx] < this.rank[ry]) {
                int w = rx;
                rx = ry;
                ry = w;
            } else if (this.rank[rx] == this.rank[ry]) {
                this.rank[rx] += 1;
            }
            this.par[ry] = rx;
            this.size[rx] += this.size[ry];
            return true;
        }
        public bool isSame(int x, int y) {
            return this.root(x) == this.root(y);
        }
        public int getSize(int x) {
            return this.size[this.find(x)];
        }
        public int root(int x) { return this.find(x); }
        public bool unite(int x, int y) { return this.union(x, y); }
    }
