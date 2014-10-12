$(document).ready(function () {
    //设置选中的课程
    $("#Course").val($("#CourseId").val());
    //为‘设为答案’复选框设置单击事件 
        
    $("input[type='checkbox']").filter(".setAnswer").click(function () {
        if ($("#Select" + this.name).val() == ""){
            ShowMessage("该选项为空,不可设置为答案！");
            this.checked=false;
            return;
        }
        SetAnswersToHiddenInput();
    });
    //将相应答案复选框选中
    SetAnswersToCheckBox();
    //判断题选中正确的答案
    SetTrueFalseRadio();
});

function Add(qType) {
    var date = new Date();
    $.ajax({
        type: "POST",
        cache:false,
        url: "/question/operate/" + qType + "-1-add" +"?time="+date.toLocaleTimeString(),
        data: $("#questionForm").serializeArray(),
        beforesend: function () {
            ShowMessage("操作中...！");
        },
        success: function (data) {
            alert(data.Status);
            if (data.status == 'error')
                ShowMessage("添加失败：" + data.Message);
            else {
                ShowMessage("添加成功");
                $("#" + qType + "Btn").trigger('click');
            }
        },
        error: function (a, b, c) {
            ShowMessage("操作失败,服务器错误");
        }
    });
}

function Continue(qType) {
    AddNewQuestion(qType);
}

//windowId:add edit
function CloseWindow(windowId) {
        $('#' + windowId + 'Window').window('close');
    }

function Update(questionType) {
    //$.post("/question/opertae/" + qType + "-" + $("#qId").val() + "-update",$("#questionForm").serialize());
    var date = new Date();
    $.ajax({
        type: "POST",
        cache:false,
        url: "/question/operate/" + qType + "-" + $("#qId").val() + "-update" + "?time=" + date.toLocaleTimeString(),
        data:$("#questionForm").serializeArray(),
        beforesend: function() {
            ShowMessage("操作中...！");
        },
        success: function (data) {
            if(data.statu=='error')
                ShowMessage("更新失败：" + data.Message);
            else {
                ShowMessage('更新成功');
                $("#" + qType + "Btn").trigger('click');
            }
        },
        error: function (a,b,c) {
            ShowMessage("操作失败，服务器错误");
        }
    });
}


function SetAnswersToHiddenInput() {
    var selectedItems = $(":checked").filter(".setAnswer");
    var length = selectedItems.length;
    if (length == 0) {
        return ;
    }
    length = selectedItems.length;
    var qIds = "";
    for (var i = 0; i < length; i++) {
        //alert($("#Select" + selectedItems[i].name).val());
        if (length > 1)
            qIds = qIds + selectedItems[i].name + "|";
        else {
            qIds = qIds + selectedItems[i].name;
        }
    }
    $("#Answers").val(qIds);
}

function SetAnswersToCheckBox() {
    var answers = $("#Answers").val().toString();
    if (answers.indexOf('A')!=-1)
        $("#A").attr("checked", 'true');
    if (answers.indexOf('B') != -1)
        $("#B").attr("checked",'true');
    if (answers.indexOf('C') != -1)
        $("#C").attr("checked", 'true');
    if (answers.indexOf('D') != -1)
        $("#D").attr("checked", 'true');
    if (answers.indexOf('E') != -1)
        $("#E").attr("checked", 'true');
    if (answers.indexOf('F') != -1)
        $("#F").attr("checked", 'true');
}

//填空题的操作
function InsertBlank() {
        var oldContent = $("#Content").val();
        if (oldContent.substring(oldContent.length - 1, oldContent.length) == "_") {
            $("#Content").focus();
            return;
        }
        oldContent = oldContent + "____";
        $("#Content").val(oldContent);
        $("#Content").focus();
    }

function InsertSeparator() {
        var oldContent = $("#Answers").val();
        //内容为空，直接return
        if (oldContent == "") return;
        //以|结尾，则直接return
        if (oldContent.substring(oldContent.length - 2, oldContent.length) == "| ") {
            $("#Answers").focus();
            return;
        }
        oldContent = oldContent + " | ";
        $("#Answers").val(oldContent);
        $("#Answers").focus();
    }

//判断题的操作
function SetTrueFalseRadio() {
        if ($("#Answers").val().toLowerCase()=='true' ) {
            $("#trueRadio").attr("checked", true);
        } else {
            $("#falseRadio").attr("checked", true);
        }
    }

 function SetTrueFalseToHiddenInput() {
        var truefalse = $("input[name='AnswerRadio']:checked").val();
        alert(truefalse);
        if (truefalse == "对")
            $("#Answers").val('true');
        if (truefalse == "错")
            $("#Answers").val('false');

    }
