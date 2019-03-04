//https://qiita.com/ofutonfuton/items/c17dfd33fc542c222396

class UnionFind {
    constructor(n) {
        this.par = new Array(n).fill(0).map((v, i) => i);
    }
    root(x) {
        if (this.par[x] == x) return x;
        return this.par[x] = this.root(this.par[x]);
    }
    unite(x, y) {
        let rx = this.root(x);
        let ry = this.root(y);
        if (rx == ry) return;
        this.par[rx] = ry;
    }
    same(x, y) {
        let rx = this.root(x);
        let ry = this.root(y);
        return rx == ry;
    }
}

/* コメント有り
class UnionFind {
    // par[i]:iの親の番号　(例) par[3] = 2 : 3の親が2

    constructor(n) { //最初は全てが根であるとして初期化
        this.par = new Array(n).fill(0).map((v, i) => i);
    }

    root(x) { // データxが属する木の根を再帰で得る：root(x) = {xの木の根}
        if (this.par[x] == x) return x;
        return this.par[x] = this.root(this.par[x]);
    }

    unite(x, y) { // xとyの木を併合
        let rx = this.root(x); //xの根をrx
        let ry = this.root(y); //yの根をry
        if (rx == ry) return; //xとyの根が同じ(=同じ木にある)時はそのまま
        this.par[rx] = ry; //xとyの根が同じでない(=同じ木にない)時：xの根rxをyの根ryにつける
    }

    same(x, y) { // 2つのデータx, yが属する木が同じならtrueを返す
        let rx = this.root(x);
        let ry = this.root(y);
        return rx == ry;
    }
}
*/
