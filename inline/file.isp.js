/*<!--*/
var f = file;
/*-->

                <div class="span6">
                    <h4>
                        <a href="{$f.id$}.file"><i class="icon-{$icon$}"></i>&nbsp;{$f.title$}</a>
                    </h4>
                    {$htmlEncode(f.desc)$}
                    <div class="smaller">
                        updated: {$f.timeString$}</div>
                </div>
                <div class="span6">
                    <ul class="thumbnails">
                        <!--*/
for (var k = 0; k < f.paticipated.length; k++) {
    var u = f.paticipated[k];
    /*-->
    <li>
    <!--*/
    $load('inline/user.isp.js')({ user: u, hideName: true });
    /*-->
    </li>
    <!--*/
}
/*-->
</ul>
</div><!--*/
//-->