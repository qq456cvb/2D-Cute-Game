

var str_w:String;
var str_a:String;
var str_s:String;
var str_d:String;
var result:int;
var sc;

function Start () {
	sc = GameObject.Find("SkillController").GetComponent("Skills");	
}

function Update () {
}

function MoveUp	() {
	return 1;
}

function MoveDown () {
	return 2;
}

function MoveLeft () {
	return 3;
}

function MoveRight () {
	return 4;
}

function StoreSkills () {
	str_w = sc.GetSkill("w");
	str_a = sc.GetSkill("a");
	str_s = sc.GetSkill("s");
	str_d = sc.GetSkill("d");
//	Debug.Log("w"+str_w);
//	Debug.Log("a"+str_a);
//	Debug.Log("s"+str_s);
//	Debug.Log("d"+str_d);
	CheckError(str_w);
	CheckError(str_s);
	CheckError(str_a);
	CheckError(str_d);
}

function CheckError (str:String) {
	try {
		eval(str);
	}
	catch (UnityException)
	{
		Debug.LogWarning("Non-executable");
	}
}

function Exec (str:String) {
	var temp;
	if (str == "w") {
	
		if (str_w.IndexOf(";") != -1) {
			temp = str_w.Substring(0, str_w.IndexOf(";")+1);
			str_w = str_w.Substring(str_w.IndexOf(";")+1);
			result = eval(temp);
			return(result);	
		} else {
			str_w = sc.GetSkill("w");
			return 0;
		}
	}
	else if (str == "a") {
	
		if (str_a.IndexOf(";") != -1) {
			temp = str_a.Substring(0, str_a.IndexOf(";")+1);
			str_a = str_a.Substring(str_a.IndexOf(";")+1);
			result = eval(temp);
			return(result);	
		} else {
			str_a = sc.GetSkill("a");
			return 0;
		}
	}
	else if (str == "s") {
	
		if (str_s.IndexOf(";") != -1) {
			temp = str_s.Substring(0, str_s.IndexOf(";")+1);
			str_s = str_s.Substring(str_s.IndexOf(";")+1);
			result = eval(temp);
			return(result);	
		} else {
			str_s = sc.GetSkill("s");
			return 0;
		}
	}
	else if (str == "d") {
	
		if (str_d.IndexOf(";") != -1) {
			temp = str_d.Substring(0, str_d.IndexOf(";")+1);
			str_d = str_d.Substring(str_d.IndexOf(";")+1);
			result = eval(temp);
			return(result);	
		} else {
			str_d = sc.GetSkill("d");
			return 0;
		}
	}
}
