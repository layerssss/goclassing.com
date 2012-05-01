/*<!--*/
$load('master/frame.master.js')({
    title: 'Users',
    head: function () {
    },
    body: function () {
        /*-->
        <div class="pagination pagination-centered" style="height:auto;">
        <ul><li class="disabled"><a href="#">«</a></li>
        <!--*/
        for (var i in alphabets) {
            var a = alphabets[i];
            var active = a == $subPage ? "active" : "";
            /*-->
            <li class="{$active$}"><a href="{$a$}.users">{$a$}</a></li>
            <!--*/
        }
        /*--><li><a href="#">»</a></li>
        </ul>
        </div>
        <hr class="clearfix" />
        <div class="panel">
        <ul class="row thumbnails">
        <!--*/
        for (var i = 0; i < users.length; i++) {
              /*-->
        <li class="span2">
        <!--*/
            $load('inline/user.isp.js')({user:users[i]});
            /*-->
            </li>
            <!--*/
        } /*-->
    </ul>
</div>
<!--*/
    }
});          //-->
