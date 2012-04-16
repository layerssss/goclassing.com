/// <reference path="/ISPReferences/master/frame.master.js" />
/*<!--*/
/*--><!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!-- Le styles -->
    <link href="/css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        body
        {
            padding-top: 60px;
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
    <!--*/
arguments[0].head(); /*-->
</head>
<body>
    <div class="navbar navbar-fixed-top">
        <div class="navbar-inner">
            <div class="container">
                <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"><span
                    class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                </a><a class="brand brand-gc" href="/">Goclassing</a>
                <div class="nav-collapse">
                    <ul class="nav">
                        <!--*/
var act1 = ($cur == 'Default.htm.isp.js') ? 'active' : '';
var act2 = (($cur == 'users.isp.js') ||
($cur == 'courses.isp.js') ||
($cur == 'tags.isp.js') ||
($cur == 'user.isp.js') ||
($cur == 'course.isp.js') ||
($cur == 'tag.isp.js')) ? 'active' : $cur;
/*-->
                        <li class="{$act1$}"><a href="/"><i class="icon-home icon-white"></i>Home</a></li>
                        <li class="dropdown {$act2$}"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                            <i class="icon-search icon-white"></i>Browse <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li><a href="/A.users"><i class="icon-user"></i>All Users</a></li>
                                <li><a href="/A.courses"><i class="icon-book"></i>All Courses</a></li>
                                <li><a href="/tags"><i class="icon-tags"></i>All Tags</a></li>
                            </ul>
                        </li>
                        <li>
                            <form class="navbar-search pull-left" action="/Search">
                            <input type="text" class="search-query" name="input" placeholder="Search" />
                            </form>
                        </li>
                        <li class="divider-vertical"></li>
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">Help
                            <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li><a href="/getting_started.course"><i class="icon-plane"></i>Get Started</a></li>
                                <li><a href="/80.file"><i class="icon-question-sign"></i>Frequently Asks</a></li>
                                <li><a href="/81.file"><i class="icon-random"></i>Connect Us</a></li>
                                <li><a href="/aboutus.classroom"><i class="icon-info-sign"></i>About Us</a></li>
                            </ul>
                        </li>
                    </ul>
                    <ul class="pull-right nav" id="slf">
                        <li class=""><a href="/" class="profile">
                            <img class="avatar" style="display: none;" /></a></li>
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
            $('[title]').tooltip({placement:'bottom'});
            $.ajax({
                url: '/Auth/GetStatus',
                dataType: 'json',
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
