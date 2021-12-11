let result = Two_sum([0, 4, 3, 0], 0);
console.log("result");
console.log(result);
function Two_sum(nums, target) {
	let dictionary = {};
	nums.forEach((num, idx) => {
		if (dictionary[num]) dictionary[num] = { num: num, idx: [...dictionary[num].idx, idx] };
		if (!dictionary[num]) dictionary[num] = { num: num, idx: [idx] };
	});
	for (var i = 0; i < nums.length; i++) {
		if (dictionary[target - nums[i]]) {
			if (dictionary[target - nums[i]].idx[0] != i) return [i, dictionary[target - nums[i]].idx[0]];
			if (dictionary[target - nums[i]].idx[0] == i && dictionary[target - nums[i]].idx[1]) return [i, dictionary[target - nums[i]].idx[1]];
		}
	}
	return 0;
}
