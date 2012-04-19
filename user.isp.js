/*<!--*/
$load('master/frame.master.js')({
    title: u.name,
    head: function () {
    },
    body: function () {
        /*-->
        <div class="row-fluid">
        <div class="span3">
        <div class="thumbnail">
        <img src="{$u.avatarUrlLarge$}" style="width: 100%; max-width: 300px;" />
        <div class="caption">
        <h5>
        Based on <a href="/82.file">our privacy policy</a>, we don't storage user's profile.</h5>
        <p>
        <a href="{$u.providerProfileLink$}" class="btn"><i class="icon-user"></i>See {$u.name$}
        on {$u.providerFriendlyName$}</a></p>
        </div>
        </div>
        </div>
        <div class="span9">
        <div class="thumbnail">
        <h3>
        Recent activities:</h3>
        <!--*/
        for (var i = 0; i < activities.length; i++) {
            var a = activities[i]; /*-->
            <p>
                <small class="pull-right">{$a.time$}</small><i class="icon-file"></i>{$a.content$}</p>
            <!--*/
        } /*-->
        </div>
    </div>
</div>
<div class="page-header">
    <h3>
        {$u.name$}'s courses:</h3>
</div>
<div class="row">
    <div class="span6">
        <div class="page-header">
            <h4>
                Teaching:</h4>
        </div>
        <!--*/
        for (var i = 0; i < teachings.length; i++) {
            var c = teachings[i];
            $load('inline/course.inline.js')({course:c});

            /*--><hr /><!--*/
        } /*-->
    </div>
    <div class="span6">
        <div class="page-header">
            <h4>
                Learning:</h4>
        </div>
        
        <!--*/
        for (var i = 0; i < learnings.length; i++) {
            var c = learnings[i];
            $load('inline/course.inline.js')({ course: c });
            /*--><hr /><!--*/
        } /*-->
    </div>
</div>
<!--*/
    }
});   //-->
