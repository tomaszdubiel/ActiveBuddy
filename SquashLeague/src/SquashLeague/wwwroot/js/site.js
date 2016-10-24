//site javascript
(function () {

    //var ele = $("#username");
    //ele.text("Tomasz Ciabalaba888");
    //
    ////mouse hover change background color
    // $("#main").on({
    //    mouseenter: function () {
    //        this.style = "background-color: #888"
    //    },
    //    mouseleave: function () {
    //        this.style = ""
    //    },
    // });
    //
    // $("ul.menu li a").on({
    //     click: function () {
    //         alert("Hello")
    //     }
    // });

    var $sidebadAndWrapper = $("#sidebar, #wrapper");
    var $icon = $("#sidebarToggle i.fa");
    
    $("#sidebarToggle").on({
        click: function () {
            $sidebadAndWrapper.toggleClass("hide-sidebar");
    
            if ($sidebadAndWrapper.hasClass("hide-sidebar"))
            {
                $icon.removeClass("fa-angle-left");
                $icon.addClass("fa-angle-right");
            }
            else
            {
                $icon.addClass("fa-angle-left");
                $icon.removeClass("fa-angle-right");
            }
        }
    });
})();