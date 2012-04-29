/*<!--*/
var c = arguments[0].course;
/*--><!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!-- Le styles -->
    <link href="/css/{$c.color$}.mybootstrap.css" rel="stylesheet" />
    <style type="text/css">
        body
        {
            padding-top: 30px;
            padding-bottom: 40px;
            
        }
    </style>
    <title><!--*/
if (typeof (arguments[0].title) == 'string') {
    $(arguments[0].title + ' - ');
} /*-->Goclassing.com</title>
    <link href="/css/responsive.css" rel="stylesheet" />
    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
<script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
    <!-- Le fav and touch icons -->
    <link rel="shortcut icon" href="/favicon.ico" />
    <link href="/css/StyleSheets.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.7.1.min.js"></script>
    <link href="/js/fancyBox/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="/js/fancyBox/jquery.fancybox.pack.js" type="text/javascript"></script>
    <script src="/js/fancyBox/helpers/jquery.fancybox-thumbs.js" type="text/javascript"></script>
    <link href="/js/fancyBox/helpers/jquery.fancybox-buttons.css" rel="stylesheet" type="text/css" />
    <script src="/js/fancyBox/helpers/jquery.fancybox-buttons.js" type="text/javascript"></script>
    <link href="/js/fancyBox/helpers/jquery.fancybox-thumbs.css" rel="stylesheet" type="text/css" />
    <script src="/js/fancyBox/jquery.mousewheel-3.0.6.pack.js" type="text/javascript"></script>
    <script src="/js/jquery.backstretch.min.js" type="text/javascript"></script>
    <script src="/js/scripts.js" type="text/javascript"></script>
    <script type="text/javascript">
        var teacherUsername = "{$c.user.username$}";
        var bg = "{$c.bg$}";
    </script>
    <script type="text/javascript">
        $(function () {
            $('.admin').toggleClass('not');
            $('[title]').tooltip({placement:'bottom'});
            $('textarea').keydown(function (e) {
                if (e.ctrlKey && e.keyCode == 13) {
                    $(this).closest("form").trigger("submit");
                }
            });
            $('a.fancybox').fancybox({
                helpers: {
                    thumbs: {
                        width: 75,
                        height: 50
                    }
                }
            });
            $.backstretch(bg, { speed: 150 });
        });
    </script>
    <!--*/
arguments[0].head();


var act1 = ($cur == 'course.isp.js') ? 'active' : '';
var act2 = (($cur == 'classroom.isp.js') ||
($cur == 'file.isp.js')) ? 'active' : $cur;
/*-->
</head>
<body data-spy="scroll" data-target=".subnav">
    <div class="navbar navbar-fixed-top">
        <div class="navbar-inner">
            <div class="container" style="position: relative">
                <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"><span
                    class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                </a><a class="brand" href="/{$c.id$}.course">
                    <img src="{$c.img$}" style="width: 35px; height: 35px; position: absolute; left: 2px;
                        top: 2px;" />
                    <span style="margin-left: 40px;">{$c.title$}</span></a>
                <div class="nav-collapse">
                    <ul class="nav">
                        <li class="divider-vertical"></li>
                        <li class="{$act1$}" ><a href="{$c.id$}.course"><i class="icon-home icon-white"></i>Introduction</a></li>
                        <li class="{$act2$}"><a href="{$c.id$}.classroom"><i class="icon-book icon-white"></i><!--*/
if (c.pub) { /*-->Plaza<!--*/ } else { /*-->Classroom<!--*/ } /*--></a></li>
                        <li class="divider-vertical"></li>
                        <li><a href="http://goclassing.com/"><span class="brand-gc-mini">Goclassing.com</span></a></li>
                    </ul>
                    <ul class="pull-right nav" id="slf">
                        <li class=""><a href="/" class="profile">
                            <img class="avatar" /></a></li>
                        <li class=""><a href="/" class="profile name"><i class="icon-time icon-white"></i>loading...</a></li>
                        <li class="">
                            <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><b
                                class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="/" class="profile"><i class="icon-user"></i>Profile</a></li>
                                    <li><a href="/Auth/Logout?redirect=%20"><i class="icon-off"></i>Logout</a></li>
                                </ul>
                            </li>
                        </li>
                        <li class="offline"><a href="#" id="fb_btn"><span>Sign in with Facebook</span></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <!--*/
arguments[0].body();
/*-->
        <hr>
        <footer>
<p>&copy; Goclassing.com 2012 <a href="/82.file">privacy</a>  <a href="https://github.com/layerssss/goclassing.com" target="_blank">source</a></p>
</footer>
    </div>
    <!-- /container -->
    <div class="modal fade" id="myModal">
        <div class="modal-header">
            <a class="close" data-dismiss="modal">×</a>
            <h3>
                Message</h3>
        </div>
        <div class="modal-body">
        </div>
        <div class="modal-footer">
            <a href="#" data-dismiss="modal" class="btn btn-primary">Close</a>
        </div>
    </div>
    <div class="modal fade" id="imgUploadingAdvice">
        <div class="modal-header">
            <a class="close" data-dismiss="modal">×</a>
            <h3>
                Image Uploading Advice</h3>
        </div>
        <div class="modal-body">
    <!--*/$load('inline/imgUploadingAdvice.inline.js')();/*-->
        </div>
        <div class="modal-footer">
            <a href="#" data-dismiss="modal" class="btn btn-primary">Close</a>
        </div>
    </div>
    <div class="loading"></div>
    <!-- Le javascript
================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script type="text/javascript" src="/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(function () {
            window.onunload = function () {
                $('.loading').show();
            };
            $.ajax({
                url: '/Auth/GetStatus',
                cache:false,
                dataType: 'jsonp',
                success: function (j) {
                    if (j.message) {
                        $('#myModal .modal-body').text(String(j.message));
                        $('#myModal').modal('show');
                    }
                    if (j.me == null) {
                        $('#slf>li').toggle();
                        $('#fb_btn').click(function () {
                            return false;
                        });
                        $.ajax({
                            url: '/Auth/GetLoginUrl',
                            data: {
                                provider: 'facebook',
                                remember: false
                            },
                            dataType: 'json',
                            success: function (j) {
                                $('#fb_btn').click(function () {
                                    window.open(j.url, null, 'toolbars=no,left=' + (window.screenX + 100) + ',top=' + (window.screenY + 120) + ',width=' + ($(window).width() - 200) + ',height=500');
                                    return false;
                                });
                            }
                        });
                    } else {
                        if (j.me.username == teacherUsername) {
                            $('.admin').toggleClass('not');
                            if (typeof (admin) == 'function') {
                                admin();
                            }
                        }
                        $('a.profile').attr('href', '/' + j.me.username + '.user');
                        $('#slf a.name').text(j.me.name);
                        $('#slf img.avatar').attr('src', j.me.avatarUrl).show();
                    }
                }
            });

        });
        var oAuthFinished = function () {
            location.reload();
        };
    </script>
    <!--*/
$load('inline/ga.inline.js')(); /*-->
</body>
</html>
<!--*/

//-->
