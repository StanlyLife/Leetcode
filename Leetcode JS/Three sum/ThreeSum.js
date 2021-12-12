nums = [-1, 0, 1, 2, -1, -4];
var threeSum = function (nums) {
	arr = [];
	for (let i = 0; i < nums.length; i++) {
		for (let j = 0; j < nums.length; j++) {
			for (let k = 0; k < nums.length; k++) {
				if (i == k || i == j || j == k) continue;
				if (nums[i] + nums[j] + nums[k] == 0) arr.push([nums[i], nums[j], nums[k]]);
			}
		}
	}
	console.log("done");
	return arr;
};

var result = threeSum(nums);
console.log(result);
