function login() {
    //获取账号密码的值
    var name = $('#name').val();
    var pwd = $('#pwd').val();

    //验证账号密码
    if (name == '' && pwd == '') {
        alert("账号或者密码不可为空");
    }

    //把数据传到服务端
    $.post("/Login/DoLogin", { 'name': name, 'pwd': pwd },
        function (data) {
            console.log(data);
            if (data == '-2') {
                $('#showInfo').html('<span style="color:red">账号或密码有误！</span>');
            } else if (data == '-1') {
                $('#showInfo').html('<span style="color:red">用户名不可为空！</span>');
            } else {
                $('#showInfo').html('<span style="color:green">登录成功！</span>');;
                window.location.href = '/home/index';
            }
        });

    //写到控制台查看
    console.log(name + ":" + pwd);
}

function reset() {
    $('#name').val('');
    $('#pwd').val('');
}

function logoff() {
    $.messager.confirm('温馨提示', '是否退出?', function (r) {
        if (r) {
            $.post("/Login/DoLogoff", null,
                function (data) {
                    if (data == '-1') {
                        $.messager.alert('温馨提示', '注销出现异常！');
                    } else {
                        $.messager.show({
                            title: '温馨提示',
                            msg: '注销成功！',
                            timeout: 1000,
                            showType: 'slide'
                        });
                        setTimeout('goLogin()', 2000);
                    }
                console.log(data);
            });
        }
    });
}

function goLogin() {
    window.location.href = '/Login/login';
}