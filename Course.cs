using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ispJs;
namespace Goclassing.com
{
    public class Course
    {
        char[] chars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '.', '_' };

        [ispJs.Action]
        public void Create(string title, string id, out string cid)
        {
            var uname = Auth.GetUsername();
            if (id.Length < 6)
            {
                throw (new Exception("Course ID must be at least 6 chars."));
            }
            if (id.Any(tc => !chars.Contains(tc)))
            {
                throw (new Exception("6(+) chars, only contains lowercase a-z, _(underscore), .(dot)"));
            }
            if (title.Length < 6)
            {
                throw (new Exception("Course title must be at least 6 chars."));
            }
            var d = Global.Entities;
            if (d.courses.Any(tc => tc.id == id))
            {
                throw (new Exception("This Course ID is already taken."));
            }
            d.courses.InsertOnSubmit(new global::course()
            {
                id = id,
                createTime = DateTime.Now,
                createuserid = d.users.First(tu=>tu.username==uname).id,
                desc = "",
                home = "",
                title = title,
                pub=false
            });
            d.SubmitChanges();

            ispJs.WebApplication.SafeDelete(title[0].ToString().ToUpper() + ".courses");
            ispJs.WebApplication.SafeDelete("Default.htm");
            cid=id;

        }
        [ispJs.Action]
        public void Join(string id)
        {
            var d = Global.Entities;
            var uname = Auth.GetUsername();
            var u = d.users.First(tu => tu.username == uname);
            var c = d.courses.First(tc => tc.id == id);
            if (c.createuserid == u.id)
            {
                throw (new Exception("You are the teacher of this course :)"));
            }
            var j = u.joining.FirstOrDefault(tj => tj.course == c);
            if (j != null)
            {
                if (j.aprooved)
                {
                    throw (new Exception("You are already in this course."));
                }
                else
                {
                    throw (new Exception("You have already applied to join this course."));
                }
            }
            j = new joining()
            {
                aprooved = false,
                courseid = c.id,
                userusername = u.username
            };
            d.joining.InsertOnSubmit(j);
            d.SubmitChanges();
            ispJs.WebApplication.SafeDelete(id + ".course");



            throw (new Exception("You have applied to join this course. Please wait for the teacher to confirm."));


        }
        [ispJs.Action]
        public void Exit(string id)
        {
            var d = Global.Entities;
            var uname = Auth.GetUsername();
            var j = d.joining.First(tj => tj.userusername == uname &&
                tj.course.id == id);
            d.joining.DeleteOnSubmit(j);
            d.SubmitChanges();
            ispJs.WebApplication.SafeDelete(id + ".course");
            ispJs.WebApplication.SafeDelete(uname + ".user");

        }
        [ispJs.Action]
        public void GetAllTags(string q, out string[] tags)
        {
            q = q.ToLower();
            var d = Global.Entities;
            var t = d.tags.Select(tt => tt.value).Distinct().ToArray();
            tags = t.Where(ts => ts.ToLower().StartsWith(q)).ToArray();
        }
        [ispJs.Action]
        public void Aproove(string id, int uid)
        {
            var d = Global.Entities;
            var myuid = Auth.GetUsername();
            var j = d.joining.First(tj => tj.course.user.username == myuid &&
                tj.courseid == id &&
                tj.user.id == uid);
            j.aprooved = true;
            d.SubmitChanges();


            ispJs.WebApplication.SafeDelete(id + ".course");
            ispJs.WebApplication.SafeDelete(j.user.username + ".user");
        }
        [ispJs.Action]
        public void Disaproove(string id, int uid)
        {
            var d = Global.Entities;
            var myuid = Auth.GetUsername();
            var j = d.joining.First(tj => tj.course.user.username == myuid &&
                tj.courseid == id &&
                tj.user.id == uid);
            d.joining.DeleteOnSubmit(j);
            d.SubmitChanges();


            ispJs.WebApplication.SafeDelete(id + ".course");
            ispJs.WebApplication.SafeDelete(j.user.username + ".user");
        }
        [ispJs.Action]
        public void Edit(string id,string desc, string title, string tags, HttpPostedFile icon, string home)
        {
            var muid = Auth.GetUsername();
            var d = Global.Entities;
            
            try
            {
                Logic.ParseChapters(home);
            }
            catch
            {
                throw (new Exception("There's one or more format error in the document."));
            }
            d.tags.DeleteAllOnSubmit(d.tags.Where(ttag => ttag.course.id == id));

            d.SubmitChanges();
            var c = d.courses.First(tc => tc.id == id && tc.user.username == muid);
            c.title = title;
            c.desc = desc;
            c.home = home;
            if (icon.FileName!="")
            {
                var a = new System.Drawing.Bitmap(icon.InputStream);
                var b = new System.Drawing.Bitmap(a, 70, 70);
                b.Save(ispJs.WebApplication.Server.MapPath("/img/course/" + id + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                b.Dispose();
                a.Dispose();
            }
            var tt = tags.Trim('[', ']').Split(',').Distinct();
            foreach (var t in tt)
            {
                var str=t.Trim('"');
                if (str == "")
                {
                    continue;
                }
                d.tags.InsertOnSubmit(new global::tag()
                {
                    courseid = id,
                    value = str
                });
            }
            d.SubmitChanges();


            ispJs.WebApplication.SafeDelete(id + ".course");
            
        }
        [ispJs.Action]
        public void AddType(string id)
        {
            var d = Global.Entities;
            var uname = Auth.GetUsername();
            var c = d.courses.First(tc => tc.id == id & tc.user.username == uname);
            foreach (var t in c.types)
            {
                t.sort++;
            }
            d.types.InsertOnSubmit(new type()
            {
                courseid=id,
                @public=true,
                sort=0,
                title=""
            });
            d.SubmitChanges();
            WebApplication.SafeDelete(id + ".classroom");
        }
        [Action]
        public void MoveUpType(int tid)
        {
            var d = Global.Entities;
            var uname = Auth.GetUsername();
            var t = d.types.First(tt => tt.id == tid && tt.course.user.username == uname);
            if (t.sort == 0)
            {
                return;
            }
            t.course.types.First(tt => tt.sort == t.sort - 1).sort++;
            t.sort--;
            d.SubmitChanges();
            WebApplication.SafeDelete(t.courseid + ".classroom");
        }
        [Action]
        public void MoveDownType(int tid)
        {
            var d = Global.Entities;
            var uname = Auth.GetUsername();
            var t = d.types.First(tt => tt.id == tid && tt.course.user.username == uname);
            if (t.sort == t.course.types.Count()-1)
            {
                return;
            }
            t.course.types.First(tt => tt.sort == t.sort + 1).sort--;
            t.sort++;
            d.SubmitChanges();
            WebApplication.SafeDelete(t.courseid + ".classroom");
        }
        [Action]
        public void DeleteType(int tid)
        {
            var d = Global.Entities;
            var id = "";
            var uname = Auth.GetUsername();
            {
                var t = d.types.First(tt => tt.id == tid && tt.course.user.username == uname);
                foreach (var tt in d.types.Where(ttt =>ttt.courseid==t.courseid&& ttt.sort > t.sort))
                {
                    tt.sort--;
                }
                id = t.courseid;
                d.types.DeleteOnSubmit(t);
            }

            d.SubmitChanges();
            WebApplication.SafeDelete(id + ".classroom");
        }
        [Action]
        public void MoveUpFile(int fid)
        {
            var d = Global.Entities;
            var uname = Auth.GetUsername();
            var t = d.doc.First(tt => tt.id == fid && tt.type.course.user.username == uname);
            if (t.sort == 0)
            {
                return;
            }
            t.type.doc.First(tt => tt.sort == t.sort - 1).sort++;
            t.sort--;
            d.SubmitChanges();
            WebApplication.SafeDelete(t.type.courseid + ".classroom");
        }
        [Action]
        public void MoveDownFile(int fid)
        {
            var d = Global.Entities;
            var uname = Auth.GetUsername();
            var t = d.doc.First(tt => tt.id == fid && tt.type.course.user.username == uname);
            if (t.sort == t.type.doc.Count() - 1)
            {
                return;
            }
            t.type.doc.First(tt => tt.sort == t.sort + 1).sort--;
            t.sort++;
            d.SubmitChanges();
            WebApplication.SafeDelete(t.type.courseid + ".classroom");
        }
        [Action]
        public void DeleteFile(int fid)
        {
            var d = Global.Entities;
            var id = "";
            var uname = Auth.GetUsername();
            {
                var t = d.doc.First(tt => tt.id == fid && tt.type.course.user.username == uname);
                foreach (var tt in d.doc.Where(ttt => ttt.typeid == t.typeid && ttt.sort > t.sort))
                {
                    tt.sort--;
                }
                id = t.type.courseid;
                d.doc.DeleteOnSubmit(t);
            }

            d.SubmitChanges();
            WebApplication.SafeDelete(id + ".classroom");
            WebApplication.SafeDelete(fid + ".file");
        }
        [Action]
        public void UploadFile(int tid,string title)
        {
            var d = Global.Entities;
            var uname = Auth.GetUsername();
            var t = d.types.First(tt => tt.id == tid && tt.course.user.username == uname);
            var f = new doc()
            {
                ext = "",
                sort = t.doc.Count(),
                title = title.Length > 0 ? title : "Untitled Document",
                desc = "",
                content = "",
                typeid = tid,
                uploadsecret = "",
                time=DateTime.Now,
            };
            d.doc.InsertOnSubmit(f);
            d.SubmitChanges();



            WebApplication.SafeDelete(t.courseid+".classroom");
        }
        [ispJs.Action]
        public void EditFile(int fid, string desc, string title, string content,HttpPostedFile file)
        {
            var muid = Auth.GetUsername();
            var d = Global.Entities;

            try
            {
                Logic.ParseChapters(content);
            }
            catch
            {
                throw (new Exception("There's one or more format error in the document."));
            }
            var f = d.doc.First(td => td.id == fid && td.type.course.user.username == muid);
            f.title = title;
            f.content = content;
            f.desc = desc;
            f.time = DateTime.Now;

            
            d.SubmitChanges();

            try
            {
                if (file.FileName!=""&&!Global.IsLocal)
                {
                    var wc = new System.Net.WebClient();
                    file.SaveAs("/srv/gctmp/" + f.id + ".gcreply");
                    wc.DownloadString(string.Format("http://static.goclassing.com/Services/PullFromDev?hash={0}&src={1}&filename={2}",
                        WebApplication.Server.UrlEncode(GCServiceBase.Validator.GetHash()),
                        WebApplication.Server.UrlEncode("gctmp/" + f.id + ".gcreply"),
                        WebApplication.Server.UrlEncode(f.id + ".gcreply")));
                    f.ext = file.FileName.Length > 0 ? file.FileName.Substring(file.FileName.LastIndexOf('.') + 1) : "";

                    d.SubmitChanges();
                }
            }
            catch
            {
                d.SubmitChanges();
                ispJs.WebApplication.SafeDelete(f.type.courseid + ".classroom");
                ispJs.WebApplication.SafeDelete(f.id + ".file");
                throw (new Exception("Soory, upload attachment failed. You may consider try uplaoding again."));
            }
                ispJs.WebApplication.SafeDelete(f.type.courseid + ".classroom");
                ispJs.WebApplication.SafeDelete(f.id + ".file");



        }
        [ispJs.Action]
        public void Comment(int fid, string content,int replyTo)
        {
            var d = Global.Entities;
            var muid = Auth.GetUsername();
            var f = d.doc.First(td => td.id == fid);
            Logic.ValidateJoin(d, f.type.course.id);
            d.replies.InsertOnSubmit(new reply()
            {
                content=content,
                docid=fid,
                fromuserid=d.users.First(tu=>tu.username==muid).id,
                time=DateTime.Now
            });
            d.SubmitChanges();
            ispJs.WebApplication.SafeDelete(f.type.courseid + ".classroom");
            ispJs.WebApplication.SafeDelete(f.id + ".file");
        }
        [ispJs.Action]
        public void DelComment(int cid)
        {

            var d = Global.Entities;
            var muid = Auth.GetUsername();
            var r = d.replies.First(tr => tr.id == cid && tr.doc.type.course.user.username == muid);
            var f = r.doc;
            d.replies.DeleteOnSubmit(r);
            d.SubmitChanges();

            ispJs.WebApplication.SafeDelete(f.type.courseid + ".classroom");
            ispJs.WebApplication.SafeDelete(f.id + ".file");
        }
        [ispJs.Action]
        public void OpenFile(int fid)
        {
            
            
            var d = Global.Entities;
            var muid = Auth.GetUsername();
            var f = d.doc.First(td => td.id == fid);
            Logic.ValidateJoin(d, f.type.courseid);
            
            var fname = f.title + "." + f.ext;
            var ext = f.ext.ToLower();
            var contentType = "application/" + ext;

            if ((new[] { "pdf" }.Contains(ext)))
            {
                fname = "";
            } 

            if ((new[] { "png", "jpg", "jpeg", "bmp", "tif", "gif" }.Contains(ext)))
            {
                contentType = "image/" + ext.Replace("jpg","jpeg");
                fname = "";
            } 
            if ((new[] { "doc" }.Contains(ext)))
            {
                contentType = "application/msword";
                fname = "";
            }
            if ((new[] { "xls" }.Contains(ext)))
            {
                contentType = "application/vnd.ms-excel";
                fname = "";
            }
            if ((new[] { "txt" }.Contains(ext)))
            {
                contentType = "text/plain";
                fname = "";
            } 
            if ((new[] { "swf" }.Contains(ext)))
            {
                contentType = "application/x-shockwave-flash";
                fname = "";
            }
            HttpContext.Current.Response.Redirect(string.Format(
                "http://static.goclassing.com/Services/DownloadFile?filehash={0}&filename={1}&alias={2}&contentType={3}",
                HttpUtility.UrlEncode(GCServiceBase.Validator.GetHash(f.id + ".gcreply")),
                HttpUtility.UrlEncode(f.id + ".gcreply"),
                HttpUtility.UrlEncode(fname),
                HttpUtility.UrlEncode(contentType)
                ));
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
            //HttpContext.Current.Response.End();
            
        }
    }
}