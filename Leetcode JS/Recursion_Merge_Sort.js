const a = [5, 2, 4, 7, 1, 3, 2, 6];
var result = MergeSort(a);
console.log(result);

function MergeSort(arr) {
	if (arr.length <= 1) return arr;

	const middle = arr.length / 2;
	if (middle > 0) {
		console.log(arr);
		let a1 = arr.slice(0, middle);
		a1.sort((one, two) => one - two);
		let a2 = arr.slice(middle, arr.length);
		a2.sort((one, two) => one - two);
		return [...MergeSort(a1), ...MergeSort(a2)].sort((one, two) => one - two);
	}

	console.log("finished");
	return arr;
}
