/*<!--*/
var u=arguments[0].user;
/*-->
<a class="thumbnail" href="{$u.username$}.user">
            <!--*/
if (!arguments[0].hideName) {/*-->
    <div class="row-fluid">
        <div class="span4">
            <img src="{$u.avatarUrl$}" style="width: 100%; max-width: 50px;" /></div>
        <div class="span8">
            <h5>
                {$u.name$}</h5>
        </div>
    </div>
        <!--*/
} else { /*-->

<img src="{$u.avatarUrl$}" style="width: 100%; max-width: 50px;" />
<!--*/
} /*-->
</a>
<!--*/
        //-->
