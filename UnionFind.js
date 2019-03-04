//https://qiita.com/ofutonfuton/items/c17dfd33fc542c222396

class UnionFind {
    constructor(n) {
        this.rnk = new Array(n).fill(0);
        this.par = this.rnk.map((v, i) => i);
    }
    root(x) {
        if (this.par[x] == x) return x;
        return this.par[x] = this.root(this.par[x]);
    }
    unite(x, y) {
        let rx = this.root(x);
        let ry = this.root(y);
        if (rx == ry) return;

        if (this.rnk[rx] < this.rnk[ry]) {
            this.par[rx] = ry;
        } else {
            this.par[ry] = rx;
            if (this.rnk[rx] == this.rnk[ry]) this.rnk[rx] += 1;
        }
    }
    same(x, y) {
        let rx = this.root(x);
        let ry = this.root(y);
        return rx == ry;
    }
    size(x) {
        return this.rnk[this.root(x)];
    }
    find(x) { return this.root(x); }
    union(x, y) { this.unite(x, y); }
}

/* コメント有り
class UnionFind {
    // par[i]:iの親の番号　(例) par[3] = 2 : 3の親が2

    constructor(n) { //最初は全てが根であるとして初期化
        this.rnk = new Array(n).fill(0); // 親
        this.par = rnk.map((v, i) => i); // 深さ
    }

    root(x) { // データxが属する木の根を再帰で得る：root(x) = {xの木の根}
        if (this.par[x] == x) return x;
        return this.par[x] = this.root(this.par[x]);
    }

    unite(x, y) { // xとyの木を併合
        let rx = this.root(x); //xの根をrx
        let ry = this.root(y); //yの根をry
        if (rx == ry) return; //xとyの根が同じ(=同じ木にある)時はそのまま
        //this.par[rx] = ry; //xとyの根が同じでない(=同じ木にない)時：xの根rxをyの根ryにつける
        if (this.rnk[rx] < this.rnk[ry]) {
            this.par[rx] = ry;
        } else {
            this.par[ry] = rx;
            if (this.rnk[rx] == this.rnk[ry]) this.rnk[rx] += 1;
        }        
    }

    same(x, y) { // 2つのデータx, yが属する木が同じならtrueを返す
        let rx = this.root(x);
        let ry = this.root(y);
        return rx == ry;
    }

    size(x) { // データxが含まれる木の大きさを返す
        return this.rnk[this.root(x)];
    }
}
*/

//各種アルゴリズムの C++ による実装
//http://www.prefield.com/algorithm/index.html
