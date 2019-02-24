function binarySearch(array, value) {
  let start = 0;
  let stop = array.length - 1;
  let middle = Math.floor((start + stop) / 2);

  while (array[middle] !== value && start < stop) {
    if (value < array[middle]) {
      stop = middle - 1;
    } else {
      start = middle + 1;
    }

    middle = Math.floor((start + stop) / 2);
  }

  return (array[middle] !== value) ? -1 : middle;
}

const list = [2, 5, 8, 9, 13, 45, 67, 99];
console.log(binarySearch(list, 99));