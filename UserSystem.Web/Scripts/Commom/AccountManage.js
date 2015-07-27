

$(function () {
    $('#add').click(openWin);
    $('#addUser').click(addUser);
    $('#reset').click(reset);
    $('#del').click(del);
    $('#search').click(search);
    $('#save').click(saveEdit);
    $('#save').hide();

    $('#dg').datagrid({
        onDblClickRow: function (index, rowData) {
            //alert(index + rowData);
            openWin();
            $('#name').val(rowData.Name);
            $('#pwd').val(rowData.Password);
            $('#id').val(rowData.ID);
            $('#addUser').hide();
            $('#save').show();
        }
    });

});

//添加用户
function addUser() {
    // $.messager.alert('Warning', 'The warning message');
    var name = $('#name').val();
    var pwd = $('#pwd').val();

    if (name == '') {
        $.messager.alert('Error', '用户名不可为空！');
    } else {
        $.post('/Account/AddUser', { 'name': name, 'pwd': pwd },
           function (data) {
               //alert("Data Loaded: " + data);
               if (data == '-1') {
                   $.messager.alert('Error', '用户名不可为空！');
               } else if (data == '0') {
                   $.messager.alert('Error', '添加出现异常！');
               } else {
                   $.messager.alert('温馨提示', '添加成功！');
                   closeWin();
                   //重新加载数据，把新添加的数据显示出来
                   $('#dg').datagrid('load', {
                       //这边可以传参数到服务端，分页用的
                       //code: '01', 
                       //name: 'name01'
                   });
               }
           });
    }
}


//重置
function reset() {
    $('#name').val('');
    $('#pwd').val('');
}

//弹出添加框
function openWin() {
    $('#dialog').window('open');
}

function closeWin() {
    $('#dialog').window('close');
}

//删除数据
function del() {
    $.messager.confirm('温馨提示', '确认删除?', function (id) {
        if (id) {
            var checkedItems = $('#dg').datagrid('getChecked');  //获取复选框选中的值
            var ids = [];
            $.each(checkedItems, function (index, item) {
                ids.push(item.ID);
            });
            ids = ids.join(",").toString();  //y用','把数组的每个值隔开  变成 1,2,3
            $.post('/Account/DelUser', { 'ids': ids }, function (result) {
                if (result == 'False') {
                    $.messager.alert('温馨提示', '删除出现异常！');
                } else {
                    $.messager.alert('温馨提示', '删除成功！');

                    //重新加载
                    $('#dg').datagrid('load', {
                        //这边可以传参数到服务端，分页用的
                        //code: '01', 
                        //name: 'name01'
                    });
                }
            });
            console.log(ids);
        }
    });
}

function search() {
    var name = $('#queryName').val();
    //重新加载数据，不用使用Ajax，而直接给URL赋值一个新的地址就可以了
    $('#dg').datagrid({ url: '/Account/GetDataByName?name=' + name });
}

function saveEdit() {
    var name = $('#name').val();
    var pwd = $('#pwd').val();
    var id = $('#id').val();
    $.post('/Account/Update', { 'name': name, 'pwd': pwd ,'id':id}, function (result) {
        if (result == 'False') {
            $.messager.alert('温馨提示', '更新出现异常！');
        } else {
            $.messager.alert('温馨提示', '更新成功！');
            closeWin();
            //重新加载
            $('#dg').datagrid('load', {
                //这边可以传参数到服务端，分页用的
                //code: '01', 
                //name: 'name01'
            });
            
        }
    });
}



