
var qType = "choice";
var isPublic = true;
var isPersonal = false;
var isPersonalAll = true;
var isFromTestPaper = false;
var parentWindow = window.parent.window;
var SelectChoiceQuestion = new Array();
var SelectFillingQuestion = new Array();
var SelectTrueFalseQuestion = new Array();
var SelectShortQuestion = new Array();
//表单初始化
$("document").ready(function (e) {
    LoadQuestions('/question/list/?pageSize=5&pageIndex=1&questionType=Choice');
    ChangeQType('choice');
    //初始化事件
    $(":checkbox").click(toggleCheckedCss);
    //菜单点击事件绑定
    $('#EditMenu').menu({
        onClick: function (item) {
            EditMenu(item);
        }
    });
    $('#PersonalMenu').menu({
        onClick: function (item) {
            EditMenu(item);
        }
    });

    $('#TestPaperMenu').menu({
        onClick: function (item) {
            EditMenu(item);
        },
        onShow: function () {
            if (!window.parent.isTruelyFromTestPaper) {
                //$('#toTestPaperMenuBtn').menubutton('disable');
                var item = $('#TestPaperMenu').menu('findItem', '选入试卷');
                $('#TestPaperMenu').menu('disableItem', item.target);
            }
        }
    });

    //隐藏暂且不显示的对话框
    $('#editWindow').hide();
    $('#delWindow').hide();
    $('#addWindow').hide();
    //如果变量定义了说明，这是来自试卷的调用，启用To试卷菜单
    if ('undefined' != typeof window.parent.isTruelyFromTestPaper) {
        SelectChoiceQuestion = window.parent.TotalCQIdList;
        SelectFillingQuestion = window.parent.TotalFQIdList;
        SelectTrueFalseQuestion = window.parent.TotalTQIdList;
        SelectShortQuestion = window.parent.TotalSQIdList;
        SetChecked();
        isFromTestPaper = true;
    }
    if ('undefined' == typeof window.parent.isTruelyFromTestPaper) {
        $("#SelectToTestPaperBtn").remove();
    }
});


//异步加载question
function LoadQuestions(urls) {
    urls += "&isPublic=" + isPublic;
    urls += "&isPersonal=" + isPersonal;
    urls += "&isPersonalAll=" + isPersonalAll;
    $.ajax({
        url: urls,
        cache: false,
        success: function (msg) {
            $("#listUIMode").html(msg);
            //$('#delWindow').window('close');
            ajustHeight();
        },
        beforeSend: function () {
            //ShowMessage("正在加载...");
        },
        error: function (a, b, c) {
            $("#listUIMode").html("数据被删光了....");
        },
        complete: function () {
            //$('#delWindow').window('close');
            SetChecked();
        }
    });


}

function CheckWhatShoudChecked() {
    GetAllCheckedID();
}
//选中该选中的
function SetChecked() {
    var array = new Array();
    switch (qType) {
        case 'choice':
            array = SelectChoiceQuestion; break;
        case 'filling':
            array = SelectFillingQuestion; break;
        case 'truefalse':
            array = SelectTrueFalseQuestion; break;
        case 'short':
            array = SelectShortQuestion; break;
        default:
            break;
    }
    for (var index = 0; index < array.length ; index++) {
        var item = $("input[name='q(" + array[index] + ")']");
        if (item) {
            item.attr("checked", 'checked');
        }
    }

}

//去掉取消选中的
function DeleteUnchecked(array) {
    var allUnCheckedItems = $(":not(:checked)").filter(".chooseQuestion");
    var uqIdArray = new Array();
    for (var uindex = 0; uindex < allUnCheckedItems.length; uindex++) {
        uqIdArray[uindex] = allUnCheckedItems[uindex].value;
    }
    if (uqIdArray.length < 1) return array;
    for (var j = 0; j < uqIdArray.length; j++) {
        var uqId = uqIdArray[j];
        if ($.inArray(uqId, array) != -1) {
            for (var i = 0; i < array.length; i++) {
                if (array[i] == uqIdArray[j])
                    array[i] = 0;
            }
        }
    }
    return array;
}

//保存选中的,数组是值传递导致重复代码过多！
function GetAllCheckedID() {
    var allCheckedItems = $(":checked").filter(".chooseQuestion");
    if (allCheckedItems.length < 0) {
        return;
    }
    var qIdArray = new Array(allCheckedItems.length);
    for (var index = 0; index < allCheckedItems.length; index++) {
        qIdArray[index] = allCheckedItems[index].value;
    }

    if (qType == 'choice') {
        SelectChoiceQuestion = SelectChoiceQuestion.concat(qIdArray);
        SelectChoiceQuestion = DeleteUnchecked(SelectChoiceQuestion);
        SelectChoiceQuestion = UniqueArray(SelectChoiceQuestion);
    }
    if (qType == 'filling') {
        SelectFillingQuestion = SelectFillingQuestion.concat(qIdArray);
        SelectFillingQuestion = DeleteUnchecked(SelectFillingQuestion);
        SelectFillingQuestion = UniqueArray(SelectFillingQuestion);
    }
    if (qType == 'truefalse') {
        SelectTrueFalseQuestion = SelectTrueFalseQuestion.concat(qIdArray);
        SelectTrueFalseQuestion = DeleteUnchecked(SelectTrueFalseQuestion);
        SelectTrueFalseQuestion = UniqueArray(SelectTrueFalseQuestion);
    }
    if (qType == 'short') {
        SelectShortQuestion = SelectShortQuestion.concat(qIdArray);
        SelectShortQuestion = DeleteUnchecked(SelectShortQuestion);
        SelectShortQuestion = UniqueArray(SelectShortQuestion);
    }
    //alert(SelectChoiceQuestion.toString() + '-'
    //    + SelectFillingQuestion.toString() + '-'
    //    + SelectTrueFalseQuestion.toString() + '-'
    //    + SelectShortQuestion.toString());
    //alert(qIdArray.toString());
}

function UniqueArray(array) {
    if (!array || array.length < 1)
        return new Array();
    var str = array.toString();
    array = array.sort();
    var newArray = new Array();
    var newIndex = 0;

    var curNumber = array[0];
    newArray[0] = array[0];
    for (var index = 0; index < array.length; index++) {
        if (curNumber != array[index]) {
            //新数字出现
            curNumber = array[index];
            newIndex++;
            newArray[newIndex] = curNumber;
        }

    }
    array = newArray;
    return array;
}

//更改当前所选问题类型
function ChangeQType(type) {
    qType = type;
}

//编辑菜单
function EditMenu(item) {
    switch (item.text) {
        case '添加':
            AddNewQuestion(); break;
        case '删除所有选中':
            DeleteQuestion(); break;
        case '修改第一个选中':
            ViewQuestion(); break;
        case '全选':
            toggleCheckAll();
            CheckWhatShoudChecked(); break;
        case '新窗口打开':
            window.open("/question/index"); break;
        case '个人题库':
            DisplayPersonnalQuestion('all'); break;
        case '个人私有题库':
            DisplayPersonnalQuestion('private'); break;
        case '个人公开题库':
            DisplayPersonnalQuestion('public'); break;
        case '总题库':
            DisplayPersonnalQuestion('allPublic'); break;
        case '选入试卷':
            PassSelectedToTestPaper();
            break;
    }
    if (item.text.toString().search("题") != -1) {
        $(".selectMenuItem").removeClass("selectMenuItem");
        item.target.className = 'menu-item selectMenuItem';
    }

}

//选入试卷
function PassSelectedToTestPaper() {
    //传递选中的试题编号
    window.parent.CurCQIdList = SelectChoiceQuestion;
    //parentWindow.TotalCQIdList = parentWindow.TotalCQIdList.concat(SelectChoiceQuestion);
    window.parent.CurFQIdList = SelectFillingQuestion;
    //parentWindow.TotalFQIdList = parentWindow.TotalFQIdList.concat(SelectFillingQuestion);
    window.parent.CurTQIdList = SelectTrueFalseQuestion;
    //parentWindow.TotalTQIdList = parentWindow.TotalTQIdList.concat(SelectTrueFalseQuestion);
    window.parent.CurSQIdList = SelectShortQuestion;

    window.parent.$("#AddSmallQuestionDialog").window("close");
    //parentWindow.TotalSQIdList = parentWindow.TotalSQIdList.concat(SelectShortQuestion);
    //window.parent.$("#AddSmallQuestionDialog").window().fadeOut("slow", function () {
    //    //最后关闭窗口
            

    //});
}

//显示个人题库
function DisplayPersonnalQuestion(displayMode) {
    switch (displayMode) {
        case 'all':
            isPersonal = true;
            isPersonalAll = true; break;
        case 'private':
            isPersonalAll = false;
            isPersonal = true;
            isPublic = false;
            break;
        case 'public':
            isPersonalAll = false;
            isPersonal = true;
            isPublic = true;
            break;
        case 'allPublic':
            isPersonal = false;
            isPersonalAll = false;
            isPublic = true;
            break;
    }
    $("#" + qType + "Btn").trigger('click');
}
//获取选中的项目的Id,没有选中直接返回
function GetSelectedQuestions() {
    var selectedItems = $(":checked").filter(".chooseQuestion");
    var length = selectedItems.length;
    if (length == 0) {
        return "";
    }
    length = selectedItems.length;
    var qIds = "";
    for (var i = 0; i < length; i++) {
        if (length > 1)
            qIds = qIds + selectedItems[i].value + "|";
        else {
            qIds = qIds + selectedItems[i].value;
        }
    }
    return qIds;
}
//获取选中的第一个项目的Id
function GetFirstSelectedQuestionId() {
    return $(":checked").filter(".chooseQuestion").first().val();
}
//查看选中的第一个项目
function ViewQuestion(questionId) {
    var qId;
    if (questionId == null)
        qId = GetFirstSelectedQuestionId();
    else {
        qId = questionId;
    }
    if (qId == null) return;
    var qOperateType = "view";
    var urls = "/question/operate/" + qType + "-" + qId + "-" + qOperateType;
    $('#editWindow').show();
    $('#editWindow').window({
        title: qTypeTOString() + '详细信息',
        width: 700,
        height: 600,
        top: 40,
        modal: true,
        closed: false,
        collapsed: false,
        cache: false,
        minimizable: false,
        maximizable: true,
        collapsible: false,
        noheader: false,
        href: urls,
        loadingMessage: '正在查看...',
        content: ContentData('view')
    });
}
//新添
function AddNewQuestion() {
    var title = qTypeTOString();
    $('#addWindow').show();
    $('#addWindow').window({
        title: "添加" + title,
        width: 700,
        top: 40,
        modal: true,
        closed: false,
        collapsed: false,
        cache: false,
        minimizable: true,
        maximizable: true,
        collapsible: false,
        noheader: false,
        href: '/question/operate/' + qType + '-1-add',
        loadingMessage: '正在加载...',
        content: ContentData('view')
    });
    //setTimeout("$('#editWindow').window('close')",1500);
}
//删除选中的项目
function DeleteQuestion() {
    //获取所有选中的Id
    var qIds = GetSelectedQuestions();
    if (qIds == "") return;
    var qOperateType = "delete";
    var urls = "/question/operate/" + qType + "-" + qIds + "-" + qOperateType;
    //发送请求
    $.ajax({
        type: "post",
        url: urls,
        cache: false,
        //data:{ "name": "wuzifei", "password": "wuzifei", "male": "boy" } ,                  
        error: function (msg, data, error) {
            alert(error);
        },
        beforeSend: function () {
            ShowMessage("正在删除...");
        },
        success: function () {
            ShowMessage("删除成功...");
            $(":checked").filter(".chooseQuestion").hide();
            UpdateQuestion(qType);
        },
        complete: function () {
            $('#delWindow').window('close');
        },
    });
}

//刷新指定页面
function UpdateQuestion(questionType) {
    var curPageIndex = $(".curPage").html();
    LoadQuestions('/question/list/?pageSize=5&pageIndex=' + curPageIndex + '&questionType=' + qType);
}

function UpdateCurrentQuestion() {
    LoadQuestions('/question/list/?pageSize=5&pageIndex=1&questionType=' + qType);
}

//显示操作信息
function ShowMessage(msg) {
    $('#delWindow').show();
    $('#delWindow').window({
        title: 'My Dialog',
        width: 200,
        height: 30,
        closed: false,
        collapsed: false,
        cache: false,
        noheader: true,
        content: msg,
    });
    setTimeout("$('#delWindow').window('close')", 3000);
}

function qTypeTOString() {
    var title = "试题";
    if (qType == "choice")
        title = "选择题";
    if (qType == "filling")
        title = "填空题";
    if (qType == "truefalse")
        title = "判断题";
    if (qType == "short")
        title = "简答题";
    return title;

}

function ContentData(type) {
    if (type == 'del')
        return "正在删除...";
    if (type == 'add') {
        return "姓名<input type='text' value='wuzifei'/>";
    }
    if (type == 'update') {
        return '修改中...';
    }
    if (type == 'view') {
        return '查看中....';
    }
    return '操作中...';
}

//切换CheckBox的选中样式
function toggleCheckedCss() {
    $(":checkbox").css("background-color", "#09f");
    $(":checked").css("background-color", "#00C");
}

//切换显示模式
function toggleDisplayMode() {
    if (isPublic) {
        isPublic = false;
    }
    else {
        isPublic = true;
    }
    $("#" + qType + "Btn").trigger('click');
}

//调整'选择框'高度
function ajustHeight() {
    //var a = document.getElementById("questiontitleContent");
    //var b = document.getElementById("questionContent");
    //if (a.scrollHeight < b.scrollHeight)
    //{
    //    $(".chooseQuestion").css('height', b.scrollHeight + "px");
    //    //c.style.height = b.scrollHeight+"px"
    //    //我在实际操作中因为左边有最小高度，所以此处设定成了固定值。
    //}
    //使列表第一个元素向上靠齐
    $(".questionItem").first().css('margin-top', 0);
}

//列表元素全选
function toggleCheckAll() {
    if ($(":checkbox").filter(".chooseQuestion").length != $(":checked").filter(".chooseQuestion").length) {
        $(":checkbox").attr('checked', "checked");
    }
    else {
        $(":checkbox").attr('checked', false);
    }
    toggleCheckedCss();
}

