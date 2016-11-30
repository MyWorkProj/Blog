var bb = new Object();
bb.aaa = "1";
bb.bbb = "2";
bb.ccc = "3";
bb.ddd = "4";
bb.name = "bb";

var cc = new Object();
cc.aaa = "11";
cc.bbb = "22";
cc.ccc = "33";
cc.ddd = "44";
cc.name = "cc";

var aa = new Object();
aa["bb"] = bb;
aa["cc"] = cc;
aa["b"].aaa