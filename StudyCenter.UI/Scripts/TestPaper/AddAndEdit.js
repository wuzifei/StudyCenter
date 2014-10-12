
$(document).ready(function () {
    //‘添加大题按钮’位置初始化及滚动事件绑定
    ScrollTheAddBigQuestionButton();
    window.onscroll = ScrollTheAddBigQuestionButton;
    window.onresize = ScrollTheAddBigQuestionButton;
    $(".CloseWindow").click(function () {
        $("#AddBigQuestionDialog").dialog('close');
    });
    $("input[type='text']").focus(function () { this.select(); });
    InitTimePicker();
    InitDropDownList();
    InitPublishRadioButton();
    //定时保存试卷,三分钟保存一次
    setInterval(TimerSaveTestPaper, 180000);
	 //只有编辑页面才需要初始化这些
    if ($("#CqList")[0]) {
		 TotalCQIdList = $("#CqList")[0].value.split(',');
		 TotalFQIdList = $("#FqList")[0].value.split(',');
		 TotalTQIdList = $("#TqList")[0].value.split(',');
		 TotalSQIdList = $("#SqList")[0].value.split(',');
	}
});

//设置发布为单选按钮的字体样式
function InitPublishRadioButton() {
    $(".PublishAsClass").bind("click", function (e) {
        $("#PaperPublishAs label").css({"color":"black","font-weight":"normal"});
        var radio = e.currentTarget;
        if (radio.nextSibling.style) {
            radio.nextSibling.style["font-weight"] = "bold";
            radio.nextSibling.style.color = "red";
        }
        if (radio.nextSibling.nextSibling.style) {
            radio.nextSibling.nextSibling.style.fontWeight = "bold";
            radio.nextSibling.nextSibling.style.color = "red";
        }
        PublishAs = radio.id;
    });
}

//TODO:因为checked 为C#关键字，导致需要转换!
function TreeDataFilter(data) {
    var curNodes = new Array();
    for (var i = 0; i < data.length; i++) {
        var curNode = data[i];
        if(curNode.children)
            curNodes[i] = { "id": curNode.id, "text": curNode.text, "checked": curNode.Checked, "children": TreeDataFilter(curNode.children) }
        else
            curNodes[i] = { "id": curNode.id, "text": curNode.text, "checked": curNode.Checked}
    }
    return curNodes;
}

function InitDropDownList() {
    $('#PublishTo').combotree({
        url: '/testpaper/GetAcademyDepartment/'+$("#TestPaperID")[0].value,
        method: "get",
        width:500,
        height:30,
        multiple: true,
        checkbox: true,
        panelHeight: 180,
        required: true,
        missingMessage: "指定人群不可为空",
        loadFilter: function (data, parent) {
            return TreeDataFilter(data);
        },
        onSelect:function() {
            var textBox = $('#PublishTo').combotree("textbox");
            textBox.css("background-color", "#fff");
            //GetSelectNodes();
        }
    });
    var tree = $('#PublishTo').combotree("tree");
    tree.tree({
        checkbox: true,
    });

    $('#PublishToAllOrNot').combobox({
        width: 80,
        height: 30,
        multiple: false,
        panelHeight: 45,
        required: true,
        missingMessage: "不可为空！",
        onSelect:function(record) {
            var textBox;
            if (record.value == 2) {
                $('#PublishTo').combotree({ "disabled": true });
                textBox = $('#PublishTo').combotree("textbox");
                textBox.css("background-color","#a9a9a9");
            }
            if (record.value == 1) {
                $('#PublishTo').combotree({ "disabled": false });
                textBox = $('#PublishTo').combotree("textbox");
                textBox.css("background-color", "#fff");
            }
        }
    });

}

function AddShowMessage(message) {
    $("#MessageBox").dialog({
        noheader: true,
        width:80,
        height: 30,
        closed: false,
        cache: false,
        modal: true,
        border: false,
        content: message
    });
    //$("#MessageBox").dialog("open");
}

function ChangeMessage(newMessage) {
    $("#MessageBox").dialog({ "content": newMessage });
}

function HideMessage() {
    $("#MessageBox").dialog("close");
}

function DelayHideMessage(millSecond) {
    setTimeout(HideMessage, millSecond);
}

function ChangeCategory() {
    var val = $("#BigCategory")[0].value;
    $.ajax({
        url: "/TestPaper/SmallCategory/" + val,
        type: "get",
        success:
            function(msg) {
                $("#SmallCategory")[0].remove("option");
                var str = "";
                for (var i = 0; i < msg.Data.length; i++) {
                    str += "<option value=" + msg.Data[i].Value + ">" + msg.Data[i].Text + "</option>";
                }
                $("#SmallCategory")[0].innerHTML = str;
            },
        error:
            function(a, b, c) {
                alert(a.responseText);
            }
    });
}



function InitTimePicker() {
    $(".Time").first().datetimebox({
        required: true,
        editable: false,
        currentText: "今天",
        closeText: "关闭",
        okText: "确认",
        showSeconds: false,
        invalidMessage: "开始时间不能设为过去",
        missingMessage:"开始时间不能为空",
        validType:'startTime',
        //formatter: function(date) {
        //    var y = date.getFullYear();
        //    var m = date.getMonth() + 1;
        //    var d = date.getDate();
        //    var h = $(".Time").first().datetimebox("spinner").timespinner("getHours");
        //    var mi = $(".Time").first().datetimebox("spinner").timespinner("getMinutes");
        //    var s = $(".Time").first().datetimebox("spinner").timespinner("getSeconds");
        //    return y + '-' + m + '-' + d + " " + h + ":" + mi ;
        //},
    });
    $(".Time").last().datetimebox({
        required: true,
        editable:false,
        currentText: "今天",
        closeText: "关闭",
        okText: "确认",
        showSeconds: false,
        invalidMessage: "结束时间至少要在开始时间之后5分钟",
        missingMessage: "结束时间不能为空",
        validType:'endTime',
        //formatter: function(date) {
        //    var y = date.getFullYear();
        //    var m = date.getMonth() + 1;
        //    var d = date.getDate();
        //    var h = $(".Time").last().datetimebox("spinner").timespinner("getHours");
        //    var mi = $(".Time").last().datetimebox("spinner").timespinner("getMinutes");
        //    var s = $(".Time").last().datetimebox("spinner").timespinner("getSeconds");
        //    return y + '-' + m + '-' + d + " " + h + ":" + mi ;
        //},

    });
    $(".Time").first().datetimebox("calendar").calendar({
        firstDay: 1,
        weeks: ['日', '一', '二', '三', '四', '五', '六'],
        months: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月']
    });
    $(".Time").last().datetimebox("calendar").calendar({
        firstDay: 1,
        weeks: ['日', '一', '二', '三', '四', '五', '六'],
        months: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月']
    });

    //var curDate = new Date();
    //var str = (curDate.getMonth() + 1) + "-" + (curDate.getDate() + 2) + "-" + curDate.getFullYear() + " "
    //    + (curDate.getHours()) + ":" + curDate.getMinutes() + ":00";
    ////alert(str);
    //$(".Time").first().datetimebox('setValue', str);
    //str = (curDate.getMonth() + 1) + "-" + (curDate.getDate() + 2) + "-" + curDate.getFullYear() + " "
    //    + (curDate.getHours() + 2) + ":" + curDate.getMinutes() + ":00";
    ////alert(str);
    //$(".Time").last().datetimebox('setValue', str);
    //$(".Time").last().datetimebox('setValue', str);

}

function NoEndTime() {
    var str = 12 + "-" + 30 + "-" + 9999 + " " + 12 + ":" + 00 + ":00";
    $(".Time").last().datetimebox('setValue', str);
}

//对‘添加大题按钮’位置的控制函数
function ScrollTheAddBigQuestionButton() {
    $("#AddBigQuestionDiv").css("top", window.innerHeight / 2 + window.pageYOffset);
    $("#AddBigQuestionDiv").css("left", (window.innerWidth - 750) / 2 + 650);
    $("#SaveTestPaperDiv").css("top", window.innerHeight / 2 + window.pageYOffset + 30);
    $("#SaveTestPaperDiv").css("left", (window.innerWidth - 750) / 2 + 650);
}

function OpenAddBigQuestionDialog() {
    $("#AddBigQuestionDialog").dialog({
        title: '编辑大题',
        width: 650,
        height: 190,
        closed: false,
        cache: false,
        modal: true,
        onBeforeClose: function() {
            $("#UpdateBigQuestion").unbind("click");
        }
    });
}

function AddBigQuestionItem() {
    OpenAddBigQuestionDialog();
    $("#AddBtns").show();
    $("#UpdateBtns").hide();
}

function AddBigQuestionToServer(isContinue) {
    if ($("#BigQuestionTitle").attr("value") == "") {
        alert("标题为空!");
        return;
    }
    var orignalUrl = "/testpaper/addbigquestion?";
    var bqTitle = $("#BigQuestionTitle").attr('value');
    var bqRemark = $("#BigQuestionRemark").attr('value');
    var bqSocre = $("#BigQuestionScore").attr('value');
    var testPaperId = $("#TestPaperID").attr("value");
    orignalUrl += "&title=" + bqTitle;
    orignalUrl += "&remark=" + bqRemark;
    orignalUrl += "&score=" + bqSocre;
    orignalUrl += "&testPaperId=" + testPaperId;
    orignalUrl = encodeURI(orignalUrl);
    //添加到服务器
    $.ajax({
        url: orignalUrl,
        cache: false,
        type: "post",
        success: function(msg) {
            ChangeMessage("添加成功！");
            if (msg.Status == 'ok') {
                AppendBigQuestion(isContinue, msg.Data.BigQuestionId, $("#BigQuestionScore").attr('value'));
                $("#TestPaperID").attr("value", msg.Data.TestPaperId);
            } else alert(msg.Message);

        },
        beforeSend: function() {
            AddShowMessage("添加中...");
        },
        error: function(a, b, c) {
            ChangeMessage("添加失败！.");
            alert(a.responseText);
        },
        complete: function() {
            DelayHideMessage(400);
        }
    });
}

function AppendBigQuestion(isContinue, bQId, score) {

    var bQLocalId = Math.abs($("#bigQuestionCount").attr("value")) + 1;
    //大题不应超过20个，大题应节制，小题无限量
    if (bQLocalId > 20) {
        alert('最多添加20个大题！');
        return;
    }
    var btnString = "";
    //大题标题
    btnString += "<div class='bigQuestion' id='BQ-" + bQId + "'>";
    btnString += "<div class='bigQuestionTitle questionTitle'>";
    if ($("#BigQuestionRemark").attr("value") == "")
        $("#BigQuestionRemark").attr("value", '无说明信息');
    //var qTitle = $("#BigQuestionTitle").attr("value")
    //    + "(" + $("#BigQuestionRemark").attr("value")
    //    + "，共：" + $("#bigquestionscore").attr("value") 
    //    + ")";
    btnString += "<h2><label class='bigQuestionNumber'>" + chinesNumber[bQLocalId] + ".</label>"
        + "<span class='BigQuestionTitle'>" + $("#BigQuestionTitle").attr("value") + "</span>"
        + "<span>(</span>"
        + "<span class='BigQuestionRemark'>" + $("#BigQuestionRemark").attr("value") + "</span>"
        + "<span>)</span>";
    btnString += "<span style='display: block;float: right;'>";
    btnString += "<input type='hidden' id='Score-" + bQId + "' value='" + score + "'/>";
    btnString += " <input type='button' onclick='DeleteBigQuestion(" + bQId + ");' value='删除'/>";
    btnString += " <input type='button' onclick='UpdateBigQuestion(" + bQId + ");' value='修改'/>";
    btnString += "</span></h2></div>";
    //大题中的小题容器
    btnString += "<ul class='questionItems' style='list-style:none;'></ul>";
    //按钮
    btnString += "<ul class='addSmallItemButton' style='list-style:none;'>";
    btnString += "<li><a  class='addLink' style='margin-left: 140px;' href='javascript:AddSmallQuestion(" + bQId + ");'>";
    btnString += "<div class='addContent' ><div class='addLeft'></div><div class='addCenter'> </div><div class='addRight'></div></div>";
    btnString += "</a></li></ul>";
    $(".allQuestion").append(btnString);
    $("#bigQuestionCount").attr("value", bQLocalId);

    //清空对话框内容
    $("#BigQuestionTitle").attr("value", "");
    $("#BigQuestionRemark").attr("value", "");

    //如果不继续则关闭对话框
    if (!isContinue)
        $("#AddBigQuestionDialog").dialog('close');
}

//bQId 本大题ID
function DeleteBigQuestion(bQId) {
    if ($("#bigQuestionCount").attr("value") == 1 && !confirm("已是最后一题,删除时也会删除该试卷,确认删除？")) {
        return;
    }
    //confirm("删除该大题,将会删除其中的所有小题，确认删除？")
    if (true) {
        var urls = "/testpaper/DeleteBigQuestion?bigQuestionId=" + bQId;
        $.ajax({
            url: urls,
            type: "post",
            cache: false,
            success: function(msg) {
                $("#BQ-" + bQId).fadeOut("slow", function() {
                    UpdateQuestionIds(bQId);
                    //更新试卷ID，因为试卷试题被删光了，试卷也会被删除
                    $("#TestPaperID").attr("value", msg.Data.TestPaperId);
                    //界面上移除该问题
                    $("#BQ-" + bQId).remove();
                    var Id = Math.abs($("#bigQuestionCount").attr("value")) + 0;
                    Id -= 1;
                    $("#bigQuestionCount").attr("value", Id);
                    //重新调整序号
                    AjustBigQuestionNumber();
                    AjustSmallQuestionNumber();
                    //更新客户端全局试题ID集合数据
                });
                if (msg.Status == "error")
                        alert(msg.Message);

            },
            beforeSend: function() {
            },
            error: function(a, b, c) {
                alert(a.responseText + "-" + b + "-" + c);
            },
            complete: function() {
            }
        });


    }

}

function UpdateQuestionIds(bQId) {
    var deletedCQ = new Array();
    var deletedFQ = new Array();
    var deletedTQ = new Array();
    var deletedSQ = new Array();
    var cqIndex = 0;
    var fqIndex = 0;
    var tqIndex = 0;
    var sqIndex = 0;
    var smallQuestion = $("#BQ-" + bQId + "> .questionItems")[0].childNodes;
    //获取删除的问题id
    for (var sq = 0; sq < smallQuestion.length; sq++) {
        var strs = smallQuestion[sq].id.split("-");
        switch (strs[0]) {
            case 'CQ':
                deletedCQ[cqIndex] = strs[2];
                cqIndex++;
                break;
            case 'FQ':
                deletedFQ[fqIndex] = strs[2];
                fqIndex++;
                break;
            case 'TQ':
                deletedTQ[tqIndex] = strs[2];
                tqIndex++;
                break;
            case 'SQ':
                deletedSQ[sqIndex] = strs[2];
                sqIndex++;
                break;
            default:
        }
    }
    //从原有集合中删除
    TotalCQIdList = IfHaveThenDelete(deletedCQ, TotalCQIdList);
    TotalFQIdList = IfHaveThenDelete(deletedFQ, TotalFQIdList);
    TotalTQIdList = IfHaveThenDelete(deletedTQ, TotalTQIdList);
    TotalSQIdList = IfHaveThenDelete(deletedSQ, TotalSQIdList);
}

//bQId 本大题ID
function UpdateBigQuestion(bQId) {
    OpenAddBigQuestionDialog();
    $("#AddBtns").hide();
    $("#UpdateBtns").show();
    var bqTitle = $("#BQ-" + bQId + " .BigQuestionTitle")[0].innerHTML;
    var bqRemark = $("#BQ-" + bQId + " .BigQuestionRemark")[0].innerHTML;
    var bqSocre = $("#Score-" + bQId).attr("value");
    $("#BigQuestionTitle").attr("value", bqTitle);
    $("#BigQuestionRemark").attr("value", bqRemark);
    $("#BigQuestionScore").attr("value", bqSocre);
    //TODO:会出现多次绑定，非常严重！
    $("#UpdateBigQuestion").one("click", function() {
        UpdateBigQuestionToServer(bQId);
    });
}

function UpdateBigQuestionToServer(bQId) {
    var bqTitle = $("#BigQuestionTitle").attr("value");
    var bqRemark = $("#BigQuestionRemark").attr("value");
    var bqSocre = $("#BigQuestionScore").attr("value");
    var orignalUrl = "/testpaper/UpdateBigQuestion?";
    orignalUrl += "&id=" + bQId;
    orignalUrl += "&title=" + bqTitle;
    orignalUrl += "&remark=" + bqRemark;
    orignalUrl += "&score=" + bqSocre;
    orignalUrl = encodeURI(orignalUrl);
    $.ajax({
        url: orignalUrl,
        cache: false,
        type: "post",
        success: function(msg) {
            ChangeMessage("修改成功...");
            if (msg) {
                $("#BQ-" + bQId + " .BigQuestionTitle")[0].innerHTML = bqTitle;
                $("#BQ-" + bQId + " .BigQuestionRemark")[0].innerHTML = bqRemark;
                $("#Score-" + bQId).attr("value", bqSocre);
                $("#UpdateBigQuestion").unbind("click", function() {
                    UpdateBigQuestionToServer(bQId);
                });
                $(".CloseWindow")[0].click();
            }
        },
        beforeSend: function() {
            AddShowMessage("修改中...");
        },
        error: function(a, b, c) {
            ChangeMessage("修改失败...");
            alert(a.responseText);
        },
        complete: function() {
            DelayHideMessage(400);
        }
    });
}

function AjustBigQuestionNumber() {
    var bigQuestionNumberItems = $(".bigQuestionNumber");
    for (var len = 0; len < bigQuestionNumberItems.length; len++) {
        var bqItem = bigQuestionNumberItems[len];
        bqItem.innerHTML = chinesNumber[len + 1] + '.';
    }
}

//qType取值为：CQ选择题/FQ填空题/TQ判断题/SQ简答题
//bQId 所属大题ID
//qId  本小题ID
function DeleteSmallQuestion(qType, bQId, qId) {
    var urls = "/testpaper/DeleteSmallQuestion?bigQuestionId=" + bQId + "&qType=" + qType + "&qId=" + qId;
    $.ajax({
        url: urls,
        cache: false,
        success: function(msg) {
            //删除客户端数据
            var target = new Array(1);
            target[0] = qId;
            switch (qType) {
                case "CQ":
                    TotalCQIdList = IfHaveThenDelete(target, TotalCQIdList);
                    break;
                case "FQ":
                    TotalFQIdList = IfHaveThenDelete(target, TotalFQIdList);
                    break;
                case "TQ":
                    TotalTQIdList = IfHaveThenDelete(target, TotalTQIdList);
                    break;
                case "SQ":
                    TotalSQIdList = IfHaveThenDelete(target, TotalSQIdList);
                    break;
                default:
            }
            //客户端和服务器上都删除成功后，在界面上移除
            $("#" + qType + "-" + bQId + "-" + qId + "").fadeOut('slow', function() {
                $("#" + qType + "-" + bQId + "-" + qId + "").remove();
                //每删除一个题目，对序列号减一
                var serialNumber = Math.abs($('#smallQuestionCount').attr("value")) - 1;
                $('#smallQuestionCount').attr("value", serialNumber);

                //重新调整序号
                AjustSmallQuestionNumber();
                if (msg.Status == "error")
                    alert(msg.Message);
            });
        },
        beforeSend: function() {
        },
        error: function(a, b, c) {
            alert(a.responseText + "-" + b + "-" + c);
        },
        complete: function() {
        }
    });

}

function AjustSmallQuestionNumber() {
    var smallQuestionNumberItems = $(".smallQuestionNumber");
    for (var len = 0; len < smallQuestionNumberItems.length; len++) {
        var bqItem = smallQuestionNumberItems[len];
        bqItem.innerHTML = len + 1 + '.';
    }
}

//compare:与之比较的数组
//target:要去比较的数组，也是要去除含有多余数据的数组
function IfHaveThenDelete(compare, target) {
    var newArray = "";
    if (compare.length == 0) return target;
    var cmpLength = compare.length - 1;
    //alert("compare.length:"+cmpLength);
    for (var tag = 0; tag < target.length; tag++) {
        for (var cmp = 0; cmp < compare.length; cmp++) {
            if ((target[tag] == compare[cmp]))
                break; //相等直接下一个循环
            //最后一个都不相等，说明是新的
            if (cmp == cmpLength) {
                //alert("target["+ tag+"]" + target[tag] +"  compare[" + cmp+"]" + compare[cmp]);
                newArray += target[tag] + ",";
            }
        }
    }
    var arr = newArray.split(",");
    return arr;
}

function AddSmallQuestion(bQId) {
    $("#AddSmallQuestionDialog").window({
        title: "从题库选取试题",
        width: 780,
        top: window.pageYOffset + 40,
        left: document.body.left,
        modal: true,
        closed: false,
        collapsible: false,
        cache: false,
        minimizable: false,
        maximizable: false,
        loadingMessage: '正在加载题库...',
        //href: "/question/index",
        content:'<iframe scrolling="false" frameborder="0"  src="/question/index" style="width:780px;height:650px;"></iframe>',
        onClose: function() {
            //对当前所选的和以前所选的进行比较，如果以前的包含了，则去除
            CurCQIdList = IfHaveThenDelete(TotalCQIdList, CurCQIdList);
            TotalCQIdList = TotalCQIdList.concat(CurCQIdList);
            CurFQIdList = IfHaveThenDelete(TotalFQIdList, CurFQIdList);
            TotalFQIdList = TotalFQIdList.concat(CurFQIdList);
            CurTQIdList = IfHaveThenDelete(TotalTQIdList, CurTQIdList);
            TotalTQIdList = TotalTQIdList.concat(CurTQIdList);
            CurSQIdList = IfHaveThenDelete(TotalSQIdList, CurSQIdList);
            TotalSQIdList = TotalSQIdList.concat(CurSQIdList);
            //alert("去除后的Current:" + CurCQIdList);
            AddSmallQuestionToServer(bQId);
        }
    });
    $("#AddSmallQuestionDialog").window().show();
    $("#AddSmallQuestionDialog").window("open");
}

function AddSmallQuestionToServer(bQId) {
    var orignalUrl = "/Testpaper/addSmallQuestion?";
    var choiceQuestions = CurCQIdList.toString();
    var fillingQuestions = CurFQIdList.toString();
    var truefalseQuestions = CurTQIdList.toString();
    var shortQuestions = CurSQIdList.toString();
    orignalUrl += "&choiceQuestions=" + choiceQuestions;
    orignalUrl += "&fillingQuestions=" + fillingQuestions;
    orignalUrl += "&truefalseQuestions=" + truefalseQuestions;
    orignalUrl += "&shortQuestions=" + shortQuestions;
    orignalUrl += "&bigQuestionId=" + bQId;
    orignalUrl += "&score=" + $("#Score-" + bQId).attr("value");
    orignalUrl = encodeURI(orignalUrl);
    $.ajax({
        url: orignalUrl,
        cache: false,
        type: "post",
        success: function(msg) {
            if (msg.Status == 'ok') {
                //遍历Data数组
                for (var i = 0; i < msg.Data.length; i++) {
                    AppendSmallQuestion(msg.Data[i].QuestionType, msg.Data[i].Id,
                        msg.Data[i].Title,msg.Data[i].Choices, msg.Data[i].Answer, bQId, $("#Score-" + bQId).attr("value"));
                    AjustSmallQuestionNumber();
                }
            } else alert(msg.Message);

        },
        beforeSend: function() {
        },
        error: function(a, b, c) {
            alert(a.toString());
        },
        complete: function() {
        }
    });
}

function AppendSmallQuestion(qType, qId, qTitle,qChoices, qAnswer, bQId, score) {

    //qId = 0; //动态设置
    //qType = "CQ"; //动态设置
    //qTitle = "测试试题"; //动态设置 形如： 填空题（总分20分）
    //qAnswer = "测试答案"; //动态设置

    var qInfo = qType + "-" + bQId + "-" + qId;
    var qDotInfo = qType + "," + bQId + "," + qId;
    var serialNumber = Math.abs($('#smallQuestionCount').attr("value")) + 1;
    var smallQuestion = "<li id=" + qInfo + ">";
    smallQuestion += "<label class='smallQuestionNumber questionTitle'>" + serialNumber + ".</label>";
    smallQuestion += "<label class='questionTitle'>" + qTitle + "</label>";
    smallQuestion += "<span style='display: block;float: right;'>";
    smallQuestion += "<input type='text' id='Score-" + qInfo + "' value='" + score + "' " +
        "onfocus='ChangeSmallQuestionScore(true," + qId + "," + qType + "," + bQId + ")'" +
        "  onblur='ChangeSmallQuestionScore(false," + qId + "," + qType + "," + bQId + ")'" +
        " style='width:20px;color:red;'/>" +
        "<font color='red'>分</font>&nbsp;&nbsp;";
    smallQuestion += "<input type='button' onclick='DeleteSmallQuestion(";
    smallQuestion += qDotInfo + ");' value='删除'/></span>";
    smallQuestion += "<br/>";
    var select = new Array('A','B','C','D','E','F');
    if (qChoices !== null || qChoices !== "") {
        for (var i = 0; i < qChoices.length; i++) {
            if (qChoices[i] != "") {
                smallQuestion += '<div class="answerContent" style="color:#36c">'+ select[i] + '.' + qChoices[i] + '</div>';
            }
        }
    }
    smallQuestion += "<div class='answerContent'>" + qAnswer + "</div>";
    smallQuestion += "</li>";
    $("#BQ-" + bQId).children(".questionItems").append(smallQuestion);
    //调整序号
    $('#smallQuestionCount').attr("value", serialNumber);
}

function ChangeSmallQuestionScore(isIn, qId, qType, bQId) {
    var qInfo = qType + "-" + bQId + "-" + qId;
    if (isIn) {
        oldScore = $("#Score-" + qInfo).attr("value");
        $("#Score-" + qInfo).select();
        return;
    }
    if ($("#Score-" + qInfo).attr("value") == oldScore)
        return;
    var urls = "/TestPaper/ChangeSmallQuestionScore?qid=" + qId + "&score=" + $("#Score-" + qInfo).attr("value");
    urls += "&bQid=" + bQId;
    urls += "&qType=" + qType;
    $.ajax({
        url: urls,
        type: 'post',
        cache: false,
        success: function(msg) {
        },
        error: function(a, b, c) {
            alert(a.responseText);
        },
        complete: function() {
        }
    });

}

//获取选中的‘面向指定人'的学院/班级/部门  的 'Kind-Id' 数组
function GetSelectNodes() {
    var checkedNodes = new Array();
    if ($('#PublishTo').combotree("options").disabled) {
        checkedNodes[0] = "All-0";
        return checkedNodes;
    }
    var index = 0;
    var tree = $('#PublishTo').combotree("tree");

    var nodes = tree.tree("getChecked");
    for (var i = 0; i < nodes.length; i++) {
        checkedNodes[i] = nodes[i].id;
    }
    var str = checkedNodes.toString();
    //alert(checkedNodes.toString());
    checkedNodes = new Array();
    var roots = tree.tree("getRoots");
    for (var i = 0; i < roots.length; i++) {
        var childres = roots[i].children;
        if (roots[i].checked) { //根节点被选中，说明选中了所有该节点的子节点，只添加根节点就行
            checkedNodes[index] = roots[i].id;
            index++;
        } else {
            if (childres) //有子节点
                for (var j = 0; j < childres.length; j++) {
                    var node = childres[j];
                    //TODO:有没有更好的方法
                    if (node.checked && str.indexOf(node.id)!=-1) {
                        checkedNodes[index] = node.id;
                        index++;
                    }
                }
        }
    }
    //alert(checkedNodes.toString());
    return checkedNodes;
}

function ShineTextBox() {
    var textBox = $("#PublishTo").combotree("textbox");
    textBox.css("background-color", "white");
}

function SaveTestPaperToServer(isPublish) {
    if (!$("#PaperName").validatebox('isValid')) {
        $("#PaperName").focus();
        isSavedOrPublished = false;
        return;
    }
    if (!$("#PublishTo").combotree('isValid')) {
        var textBox = $("#PublishTo").combotree("textbox");
        textBox.css("background-color", "red");
        setTimeout(ShineTextBox, 300);
        $("#PublishTo").combotree("textbox").focus();
        isSavedOrPublished = false;
        return;
    }
    if (!$(".Time").first().datetimebox("isValid")) {
        $(".Time").first().datetimebox("textbox").focus();
        isSavedOrPublished = false;
        return;
    }
    if (!$(".Time").last().datetimebox("isValid")) {
        $(".Time").last().datetimebox("textbox").focus();
        isSavedOrPublished = false;
        return;
    }

    var course = $("#CourseID")[0].value;
    var category = $("#SmallCategory")[0].value;
    var paperName = $("input[name='PaperName']")[0].value;
    var paperDescription = $("input[name='PaperDescription']")[0].value;
    var startTime = $("input[name='StartTime']")[0].value;
    var endTime = $("input[name='EndTime']")[0].value;
    var testMinutes = $("input[name='TestMinutes']")[0].value;
    var paperScore = $("input[name='PaperScore']")[0].value;
    var testPaperId = $("#TestPaperID")[0].value;
    var knowledge = $("#Knowledge")[0].value;
    if (knowledge == "") knowledge = "未知";
    var urls = "/testpaper/save?";
    urls += "&courseId=" + course;
    urls += "&categoryId=" + category;
    urls += "&paperName=" + paperName;
    urls += "&paperDescription=" + paperDescription;
    urls += "&startTime=" + startTime;
    urls += "&endTime=" + endTime;
    urls += "&testMinutes=" + testMinutes;
    urls += "&paperScore=" + paperScore;
    urls += "&testPaperId=" + testPaperId;
    urls += "&paperType=" + PublishAs;
    urls += "&knowledge=" + knowledge;
    urls +="&publishToIds="+GetSelectNodes().toString();
    urls = encodeURI(urls);
    //if (urls != oldUrls) {
    //    oldUrls = urls;
    //} else {
    //    return;
    //}

    $.ajax({
        url: urls,
        cache: false,
        type: "post",
        //contentType: "charset=utf-8",
        beforeSend: function() {
            AddShowMessage("保存中...");
        },
        success:
            function(msg) {
                $("#TestPaperID")[0].value = msg.Data;
                ChangeMessage("保存成功！");
                if (isPublish)
                    Redirect();
            },
        error:
            function(a, b, c) {
                ChangeMessage("保存失败！");
                alert(a.responseText);
            },
        complete: function() {
            DelayHideMessage(400);
        }
    });
}

function ValidInputBox() {
    var flag = false;
    if ($("#PaperName").validatebox('isValid')) 
        if ($("#PublishTo").combotree('isValid')) 
            if ($(".Time").first().datetimebox("isValid"))
                if ($(".Time").last().datetimebox("isValid"))
                    flag = true;
    return flag;
}

function TimerSaveTestPaper() {
    if (ValidInputBox())
        SaveTestPaperToServer();
}

function SaveAs() {
    var oldPublishAs = PublishAs;
    PublishAs = 'ToPrivate';
    SaveTestPaperToServer();
    PublishAs = oldPublishAs;
}

function Redirect() {
    window.location.href = "/study/index";
}
