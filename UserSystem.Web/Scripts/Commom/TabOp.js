$(function () {
    // // 点击西边的树形节点，在中间布局打开一个tab选项卡。
    //$('#tt').tree({
    //    //请求一个控制器的方法，控制器返回一个Content();  请求格式如下:控制器前缀名/方法名
    //    url: '/Tree/GetMenu?type=1',
    //    //url: '/Tree/Tree',
    //    //checkbox: true,
    //    onClick: function (node) {
    //        // alert(node.attributes.url);  // alert node text property when clicked
    //        // add a new tab panel  
    //        var tab = $('#tabs');
    //        if (tab.tabs('exists', node.text)) {  //如果tab已经存在，就选中那个存在的tab,否则添加
    //            tab.tabs('select', node.text);
    //        }
    //        else {
    //            $('#tabs').tabs('add', {
    //                title: node.text,
    //                content: 'Tab Body',
    //                closable: true,
    //                //content:'This is a Demo'    //这边是显示内容
    //                href: node.attributes.url        //这边是链接到一个URL地址的网页
    //            });
    //        }
    //    }
    //});


    /*  Change By ZX  in 2014.11.27 
        上面是Tree的做法，下面是拼接的li用法；
    */

    var url = '/Tree/GetMenu?type=1';
    var html="";
    $.ajax({
        url: url,
        dataType: "json",
        type:"get",
        success: function (data) {
            $.each(data, function (i, val) {
                html += "<li id=\""+val.ID+"\" name=\""+val.URL+"\" onclick=\"go('"+val.Name+"','"+val.URL+"');\">"+val.Name+"</li>";
            });
            $('#tt').append(html);
        }
    });
});

function go(name,url)
{
    var tab = $('#tabs');
    if (tab.tabs('exists', name)) {  //如果tab已经存在，就选中那个存在的tab,否则添加
        tab.tabs('select', name);
    }
    else {
        $('#tabs').tabs('add', {
            title: name,
            content: 'Tab Body',
            closable: true,
            //content:'This is a Demo'    //这边是显示内容
            href: url        //这边是链接到一个URL地址的网页
        });
    }
}
