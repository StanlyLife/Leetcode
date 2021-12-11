const exp = [
	// {
	// 	s: "mississippi",
	// 	p: "mis*is*p*.",
	// },
	{
		s: "mississ",
		p: "mis*is*",
	},
];

exp.forEach((expression) => {
	const result = RegularExpressionMatching(reverseString(expression.s), reverseString(expression.p));
	console.log(result);
});

function reverseString(str) {
	return str.split("").reverse().join("");
}

function RegularExpressionMatching(s, p) {
	console.log("---------------");
	console.log(`S: ${s}`);
	console.log(`P: ${p}`);
	//BASECASE
	if ((s == "" && p == "") || s == p) {
		console.log("TRUE!!!!!!");
		return true;
	}

	//EDGECASE
	var result = false;
	if (p[0] == "*") {
		//Keep going!
		result = IterateStar(s, p);
	}
	if (p[0] == "." || s[0] == p[0]) RegularExpressionMatching(s.substring(1), p.substring(1));
	return result;
	return RegularExpressionMatching(s.substring(1), p.substring(1));
}

function IterateStar(s, p) {
	console.log("@@@@@@@@@@@@@@@@@@@@@@@@@@@");
	console.log(`HANDLING P = ${p} && S = ${s}`);

	var result = GetAllOptions(s, p[1], p.substring(2));
	console.log("@@@@@@@@@@@ RESULT = " + result + " @@@@@@@@@@@@@@");
	return result;
	// return IterateStar(s.substring(1), p);
}

//OPTIMIZE GET ALL OPTIONS BY MOVING BOTTOM FOREACH INTO FIRST LOOP

function GetAllOptions(s, minP, p) {
	OptionsArray = [];
	if (s == "") {
		console.log("s = '' p = " + p);
		return RegularExpressionMatching(s, p);
	}
	if (minP != ".") {
		//minP = char*
		for (var i = 0; i <= s.length; i++) {
			OptionsArray.push(s.substring(i));
			if (s.substring(i)[0] != minP) {
				i = s.length;
			}
		}
	} else {
		//minP = *.
		for (var i = 0; i <= s.length; i++) {
			OptionsArray.push(s.substring(i));
			console.log(`NOT MATCH! ${s.substring(i)} TO ${s}`);
		}
	}
	var result = false;
	OptionsArray.forEach((option) => {
		console.log(`TESTING ${option} TO ${p}`);
		if (RegularExpressionMatching(option, p)) {
			console.log(`OPTION MATCHED! ${option} TO ${p}`);
			result = true;
			return true;
		} else {
			console.log("false");
		}
	});
	// console.log(s);
	// console.log(minP + "*" + " FOR: " + p);
	// console.log(OptionsArray);
	// console.log(`FAILED`);
	return result;
}
