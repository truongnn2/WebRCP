function AddNewProducts() {
    if ($("#txtTitle").val() == "") {
        alert("Bạn phải nhập tiêu đề!");
        $("#txtTitle").focus()
        return false;
    }
    if ($("#sltCategory").val() == "") {
        alert("Bạn phải chọn loại!");
        $("#sltCategory").focus()
        return false;
    }

    var oEditor = FCKeditorAPI.GetInstance('txtIntro');
    if (oEditor.GetXHTML(true) == "") {
        alert("Bạn phải nhập sơ lược về tin tức!");
        $("#txtIntro").focus()
        return false;
    }
    var oEditor1 = FCKeditorAPI.GetInstance('txtContent');
    if (oEditor1.GetXHTML(true) == "") {
        alert("Bạn phải nhập nội dung!");
        $("#txtContent").focus()
        return false;
    }
}
function changeSelect(se, hd) {
    document.getElementById("" + hd).value = document.getElementById("" + se).value;
}
var ajxProducts = {
    listProducts: function (spage) {
        $.post(PathAdmin + "/Handler/Admin.aspx", { act: "listProducts", pg: spage, kw: $("#txtKeyword").val(), type: $("#sltCategory").val(), typeDetail: $("#sltCategoryDetail").val(), IsShowDefault: $("#sltShowDefault").val() },
            function (data) {
                if (data != "") {
                    $('#ListTD').html(data);
                    var tps = (parseInt($("#hTotalRows").val()) / parseInt($("#hdfRecordCount").val()) - parseInt(parseInt($("#hTotalRows").val()) / parseInt($("#hdfRecordCount").val()))) > 0 ? ((parseInt(parseInt($("#hTotalRows").val()) / parseInt($("#hdfRecordCount").val()))) + 1) : parseInt(parseInt($("#hTotalRows").val()) / parseInt($("#hdfRecordCount").val()));
                    if (tps < $("#hCurrentPage").val())
                        $("#hCurrentPage").val() = 1;
                    if (tps == 1) $("#dvPaging").hide();
                    mjDrawLbPageNew(tps, $("#hCurrentPage").val(), "dvPaging", "gotoPage");
                }
                else {
                    $('#ListTD').html("Chưa có dữ liệu!");
                    $("#dvPaging").hide();
                }
            });
    },
    ChangeStatus: function () {
        var chked = '';
        if (document.form1.checkbox.length == undefined) {
            if (document.form1.checkbox.checked)
                chked = document.form1.checkbox.value;
        }
        else {
            for (var i = 0; i < document.form1.checkbox.length; i++) {
                if (document.form1.checkbox[i].checked) {
                    chked += document.form1.checkbox[i].value + ",";
                }
            }
        }

        if (chked == '') {
            alert("Bạn phải chọn Sản phẩm!");
            return false;
        }
        if ($("#sltStatus").val() == "") {
            alert("Bạn phải chọn trạng thái!");
            $("#sltStatus").focus()
            return false;
        }
        $.post(PathAdmin + "/Handler/Admin.aspx", { act: "ChStatusProducts", status: $("#sltStatus").val(), id: chked },
            function () {
                ajxProducts.listProducts(1);
            });
    },
    Delete: function (idtd) {
        if (!confirm('Bạn có chắc chắn muốn xóa dự án này không?'))
            return false;
        $.post(PathAdmin + "/Handler/Admin.aspx", { act: "deleteProducts", id: idtd },
            function () {
                ajxProducts.listProducts(1);
            });
    },
    DeleteImage: function (idtr, image, idtd) {
        $.post(PathAdmin + "/Handler/Admin.aspx", { act: "deleteImgProducts", id: idtd, img: image },
            function () {
                $("#" + idtr).hide();
            });
    },
    DeleteFile: function (idtr, filename, id) {
        $.post(PathAdmin + "/Handler/Admin.aspx", { act: "deletefile", filename: filename, id: id },
            function () {
                $("#" + idtr).hide();
            });
    },
    GetListCatDetail: function () {
        $.post("/Products/ListCatSub", { act: "getListCatDetail", cat: $("#sltCategory").val() },
            function (data) {
                if (data.XMLDocument != "") {
                    var lcObjXmlDoc = data;
                    var lcNodes = lcObjXmlDoc.getElementsByTagName("*")[0].childNodes;
                    if (lcNodes.length > 0) {
                        try {
                            removeSelectbox("sltCategoryDetail", "Chọn");
                            var obj_select = document.getElementById("sltCategoryDetail");
                            for (var i_ = obj_select.length - 1; i_ >= 0; i_--) {
                                obj_select.options[i_] = null;
                            }
                            for (var k = 0; k < lcNodes.length; k++) {
                                var options_length = obj_select.length;
                                var option_value = lcNodes[k].childNodes[0];
                                var option_text = lcNodes[k].childNodes[1];
                                while (option_text.childNodes[0].nodeValue.indexOf("|") != -1) {
                                    option_text.childNodes[0].nodeValue = option_text.childNodes[0].nodeValue.replace("|", "&");
                                }
                                if (k == 0)
                                    obj_select.options[options_length] = new Option("Chọn", "");
                                else
                                    obj_select.options[options_length] = new Option(option_text.childNodes[0].nodeValue, option_value.childNodes[0].nodeValue);

                                document.getElementById("sltCategoryDetail").disabled = false;
                            }
                        } catch (e) {
                            //alert(e);					
                        }
                    }

                }
                else {
                    removeSelectbox("sltCategoryDetail", "Loading...");
                }
            });
    },
    GetListCatDetailSub: function () {
        document.getElementById("hdCategoryDetailSub").value = "";
        $.post(PathAdmin + "/Handler/Admin.aspx", { act: "getListCatDetailSub", cat: $("#sltCategoryDetail").val() },
            function (data) {
                if (data.XMLDocument != "") {
                    var lcObjXmlDoc = data;
                    var lcNodes = lcObjXmlDoc.getElementsByTagName("*")[0].childNodes;
                    if (lcNodes.length > 0) {
                        try {
                            removeSelectbox("sltCategoryDetailSub", "Chọn");
                            var obj_select = document.getElementById("sltCategoryDetailSub");
                            for (var i_ = obj_select.length - 1; i_ >= 0; i_--) {
                                obj_select.options[i_] = null;
                            }
                            for (var k = 0; k < lcNodes.length; k++) {
                                var options_length = obj_select.length;
                                var option_value = lcNodes[k].childNodes[0];
                                var option_text = lcNodes[k].childNodes[1];
                                while (option_text.childNodes[0].nodeValue.indexOf("|") != -1) {
                                    option_text.childNodes[0].nodeValue = option_text.childNodes[0].nodeValue.replace("|", "&");
                                }
                                if (k == 0)
                                    obj_select.options[options_length] = new Option("Chọn", "");
                                else
                                    obj_select.options[options_length] = new Option(option_text.childNodes[0].nodeValue, option_value.childNodes[0].nodeValue);

                                document.getElementById("sltCategoryDetailSub").disabled = false;
                            }
                        } catch (e) {
                            //alert(e);					
                        }
                    }

                }
                else {
                    removeSelectbox("sltCategoryDetailSub", "Loading...");
                }
            });
    }
}

function checkall() {
    if (document.form1.check.checked == true) {
        if (document.form1.checkbox.length == undefined) {
            document.form1.checkbox.checked = true;
            return;
        }
        for (var i = 0; i < document.form1.checkbox.length; i++)
            document.form1.checkbox[i].checked = true;
    }
    else {
        if (document.form1.checkbox.length == undefined) {
            document.form1.checkbox.checked = false;
            return;
        }
        for (var i = 0; i < document.form1.checkbox.length; i++)
            document.form1.checkbox[i].checked = false
    }
}

function InitlistProducts() {
    ajxProducts.listProducts(1);
}
function gotoPage(numberpage) {
    pg = numberpage;
    ajxProducts.listProducts(numberpage);
}
function removeSelectbox(objID, initText) {
    if (initText && initText.indexOf('*') != -1)
        initText = initText.replace('***', 'Select');
    var obj_select = document.getElementById(objID);
    obj_select.disabled = true;
    for (var k = obj_select.options.length - 1; k >= 0; k--) {
        obj_select.options[k] = null;
    }
    if (initText != undefined || initText != null) {
        if (initText != '') obj_select.options[0] = new Option(initText, "");
    }
}