"use strict";
class Bigint {
  constructor(a) {
    this.mod = 1000000;
    this.value = [];
    if (typeof a === 'number') this.set_of(Math.floor(a));
    else if (a != null) this.set_value(a);
  }
  set_of(a) {
    while (a != 0) {
      this.value.push(a % this.mod);
      a = Math.floor(a / this.mod);
    }
    return this;
  }
  set_value(v) {
    this.value = v;
    return this;
  }
  add(b) {
    let a = this.value;
    if (typeof b === 'number') b = new Bigint(b).value; else b = b.value;
    let value = [];
    let i;
    let m = Math.max(a.length, b.length);
    for (i = 0; i < m; i++) {
      let r = 0;
      if (i < a.length) {
        r += a[i];
      }
      if (i < b.length) {
        r += b[i];
      }
      if (i >= value.length) {
        value.push(r % this.mod);
      } else {
        value[i] += r % this.mod;
      }
      if (r > this.mod) {
        if (i + 1 >= value.length) {
          value.push(Math.floor(r / this.mod));
        } else {
          value[i + 1] += Math.floor(r / this.mod);
        }
      }
    }
    return new Bigint(value);
  }
  multiply(b) {
    let a = this.value;
    if (typeof b === 'number') b = new Bigint(b).value; else b = b.value;
    let value = [];
    let i, j;
    for (i = 0; i < a.length; i++) {
      for (j = 0; j < b.length; j++) {
        if (i + j >= value.length) {
          value.push(a[i] * b[j]);
        } else {
          value[i + j] += a[i] * b[j];
        }
      }
    }
    for (i = 0; i < value.length - 1; i++) {
      value[i + 1] += Math.floor(value[i] / this.mod);
      value[i] %= this.mod;
    }
    if (value[value.length - 1] >= this.mod) {
      value.push(Math.floor(value[i] / this.mod));
      value[value.length - 2] %= this.mod;
    }
    return new Bigint(value);
  }
  times(b) {
    return this.multiply(b);
  }
  toString() {
    if (this.value.length < 1) return '0';
    let str = '';
    for (let i = 0; i < this.value.length - 1; i++) {
      str = (this.mod + this.value[i]).toString().substring(1).concat(str);
    }
    str = this.value[this.value.length - 1].toString().concat(str);
    return str;
  }
}
function BigInt(a) {
  return new Bigint(a);
}
/*
"use strict";class Bigint{constructor(a){this.mod=1000000;this.value=[];if(typeof a==='number')this.set_of(Math.floor(a));else if(a!=null)this.set_value(a)}set_of(a){while(a!=0){this.value.push(a%this.mod);a=Math.floor(a/this.mod)}return this}set_value(v){this.value=v;return this}add(b){let a=this.value;if(typeof b==='number')b=new Bigint(b).value;else b=b.value;let value=[];let i;let m=Math.max(a.length,b.length);for(i=0;i<m;i++){let r=0;if(i<a.length){r+=a[i]}if(i<b.length){r+=b[i]}if(i>=value.length){value.push(r%this.mod)}else{value[i]+=r%this.mod}if(r>this.mod){if(i+1>=value.length){value.push(Math.floor(r/this.mod))}else{value[i+1]+=Math.floor(r/this.mod)}}}return new Bigint(value)}multiply(b){let a=this.value;if(typeof b==='number')b=new Bigint(b).value;else b=b.value;let value=[];let i,j;for(i=0;i<a.length;i++){for(j=0;j<b.length;j++){if(i+j>=value.length){value.push(a[i]*b[j])}else{value[i+j]+=a[i]*b[j]}}}for(i=0;i<value.length-1;i++){value[i+1]+=Math.floor(value[i]/this.mod);value[i]%=this.mod}if(value[value.length-1]>=this.mod){value.push(Math.floor(value[i]/this.mod));value[value.length-2]%=this.mod}return new Bigint(value)}times(b){return this.multiply(b)}toString(){if(this.value.length<1)return'0';let str='';for(let i=0;i<this.value.length-1;i++){str=(this.mod+this.value[i]).toString().substring(1).concat(str)}str=this.value[this.value.length-1].toString().concat(str);return str}}function BigInt(a){return new Bigint(a)}
*/