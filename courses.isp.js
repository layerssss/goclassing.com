/// <reference path="/ISPReferences/courses.isp.js" />
/*<!--*/
$load('master/frame.master.js')({
    title: 'Courses',
    head: function () {
    },
    body: function () {
        /*-->
        <div class="pagination pagination-centered" style="height: auto;">
        <ul>
        <li class="disabled"><a href="#">«</a></li>
        <!--*/
        for (var i in alphabets) {
            var a = alphabets[i];
            var active = a == $subPage ? "active" : "";
            /*-->
            <li class="{$active$}"><a href="{$a$}.courses">{$a$}</a></li>
            <!--*/
        }
        /*-->
        <li><a href="#">»</a></li>
        </ul>
        </div>
        <hr class="clearfix" />
        <div class="panel">
        <div class="row">
        <!--*/
        for (var i = 0; i < courses.length; i++) {
            var c = courses[i]; /*-->
        <div class="span6">
            <!--*/
            $load('inline/course.inline.js')({ course: c }); /*-->
            <hr />
        </div>
        <!--*/
        } /*-->
    </div>
</div>
<!--*/
    }
});            //-->
