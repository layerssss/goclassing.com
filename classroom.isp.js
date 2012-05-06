/*<!--*/

$load("master/cframe.master.js")({
    title: c.title,
    head: function () {
        /*-->
<link href="css/ui-lightness/jquery-ui-1.8.18.custom.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-ui-1.8.18.custom.min.js" type="text/javascript"></script>
<script src="js/jquery.masonry.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $('.types .file').sortable({
            handle: '.btn-info',
            start: function () {

            },
            stop: function () {
                window.onresize();
            },
            helper: 'clone',
            connectWith: '.types ol'
        });
    });
    var admin = function () {
    };
</script>
<!--*/
    },
    course: c,
    body: function () {
        /*-->
<div class="row">
    <section class="span12">
        <div class="row"><div class="span12">
        <div class="well admin">
        <h5>
        Teacher's tools:</h5><a href="Course/AddType?id={$c.id$}&ANTICSRF=&redirect=%20" class="btn btn-success"><i class="icon-plus-sign icon-white"></i>Add a New Block</a>
        </div></div>
        <div class="well admin add" style="display:none;">
        <a class="close" onclick="$(this).parent().fadeOut(function(){ window.onresize();});return false;">×</a>
        <form action="Course/UploadFile?ANTICSRF=&redirect=%20" class="" method="post" enctype="multipart/form-data">
        <label for="up-title">Title:</label>
        <input id="up-title" type="text" class="" name="title" placeholder="" />
        <input type="hidden" name="tid" id="tid" />
        <div>
        <button type="submit" class="btn btn-success"><i class="icon-upload icon-white"></i>Add</button>
        <button type="button" class="btn" onclick="$(this).closest('.add').find('.close').trigger('click');">Cancel</button>
        </div>
        </form>

        </div></div>
        </section>
</div>
<div class="row types">
    <!--*/
        for (var tid in types) {
            var files = types[tid]; /*-->
    <div class="span12">
        <div class="well">
            <!--*/
            for (var j = 0; j < files.length; j++) {
                var f = files[j];
                var icon = {
                    'jpg': 'picture',
                    'jpeg': 'picture',
                    'bmp': 'picture',
                    'tif': 'picture',
                    'png': 'picture',
                    'rar': 'folder-close',
                    'zip': 'folder-close',
                    'gz': 'folder-close',
                    'tar': 'folder-close',
                    'pdf': 'file',
                    'doc': 'file',
                    'docx': 'file',
                    'pdf': 'file',
                    'xls': 'file'
                }[f.ext];
                //icons from http://twitter.github.com/bootstrap/base-css.html#icons
                icon=icon?icon:'comment';
                /*-->
            <div class="row-fluid file" style="position:relative;">
                <!--*/$load('inline/file.isp.js')({file:f});/*-->
                <div style="position: absolute; right: 10px; top: 10px;" class="admin btn-toolbar">
                    <div class="btn-group">
                        <a href="Course/MoveUpFile?ANTICSRF=&redirect=%20&fid={$f.id$}" class="btn btn-info btn-mini"
                            rel="tooltip" title="Move Up"><i class="icon-arrow-up icon-white"></i></a><a href="Course/MoveDownFile?ANTICSRF=&redirect=%20&fid={$f.id$}"
                                class="btn btn-info btn-mini" rel="tooltip" title="Move Down"><i class="icon-arrow-down icon-white">
                                </i></a>
                    </div>
                    <div class="btn-group">
                        <a href="Course/DeleteFile?ANTICSRF=&redirect=%20&fid={$f.id$}" data-confirm="All data within this topic will be DELETED, are you sure?"
                            class="btn btn-danger btn-mini" rel="tooltip" title="Delete"><i class="icon-trash icon-white">
                            </i></a>
                    </div>
                </div>
            </div>
            <!--*/
            } /*-->
            <!--*/
            if (!files.length) {/*-->
            <!--*/
            } /*-->
            <div style="text-align: right;" class="btn-toolbar admin">
                <div class="btn-group">
                    <a href="Course/MoveUpType?ANTICSRF=&redirect=%20&tid={$tid$}" class="btn btn-info btn-mini"
                        rel="tooltip" title="Move Up"><i class="icon-arrow-up icon-white"></i></a><a href="Course/MoveDownType?ANTICSRF=&redirect=%20&tid={$tid$}"
                            class="btn btn-info btn-mini" rel="tooltip" title="Move Down"><i class="icon-arrow-down icon-white">
                            </i></a>
                </div>
                <div class="btn-group">
                    <a href="Course/DeleteType?ANTICSRF=&redirect=%20&tid={$tid$}" class="btn btn-danger btn-mini"
                        rel="tooltip" data-confirm="All topics in this block will also be DELETED, are you sure?"
                        title="Delete"><i class="icon-trash icon-white"></i></a><a href="#" onclick="$('.add').hide().insertAfter($(this).parent().parent()).fadeIn().find('#tid').val('{$tid$}');window.onresize();return false;"
                            class="btn btn-success btn-mini" rel="tooltip" title="Add a New Topic"><i class="icon-plus-sign icon-white">
                            </i></a>
                </div>
            </div>
        </div>
    </div>
    <!--*/
        } /*-->
</div>
<!--*/
    }
});
//-->
