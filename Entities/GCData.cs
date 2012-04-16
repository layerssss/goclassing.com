// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from goclassing_com on 2012-04-03 11:30:36Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
using System;
using System.ComponentModel;
using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
	using DbLinq.Data.Linq;
	using DbLinq.Vendor;
#endif  // MONO_STRICT
	using System.Data.Linq.Mapping;
using System.Diagnostics;


public partial class goclassingcom : DataContext
{
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		#endregion
	
	
	public goclassingcom(string connectionString) : 
			base(connectionString)
	{
		this.OnCreated();
	}
	
	public goclassingcom(string connection, MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		this.OnCreated();
	}
	
	public goclassingcom(IDbConnection connection, MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		this.OnCreated();
	}
	
	public Table<activity> activities
	{
		get
		{
			return this.GetTable<activity>();
		}
	}
	
	public Table<course> courses
	{
		get
		{
			return this.GetTable<course>();
		}
	}
	
	public Table<doc> doc
	{
		get
		{
			return this.GetTable<doc>();
		}
	}
	
	public Table<joining> joining
	{
		get
		{
			return this.GetTable<joining>();
		}
	}
	
	public Table<reply> replies
	{
		get
		{
			return this.GetTable<reply>();
		}
	}
	
	public Table<secret> secrets
	{
		get
		{
			return this.GetTable<secret>();
		}
	}
	
	public Table<tag> tags
	{
		get
		{
			return this.GetTable<tag>();
		}
	}
	
	public Table<type> types
	{
		get
		{
			return this.GetTable<type>();
		}
	}
	
	public Table<user> users
	{
		get
		{
			return this.GetTable<user>();
		}
	}
}

#region Start MONO_STRICT
#if MONO_STRICT

public partial class goclassingcom
{
	
	public goclassingcom(IDbConnection connection) : 
			base(connection)
	{
		this.OnCreated();
	}
}
#region End MONO_STRICT
	#endregion
#else     // MONO_STRICT

public partial class goclassingcom
{
	
	public goclassingcom(IDbConnection connection) : 
			base(connection, new DbLinq.MySql.MySqlVendor())
	{
		this.OnCreated();
	}
	
	public goclassingcom(IDbConnection connection, IVendor sqlDialect) : 
			base(connection, sqlDialect)
	{
		this.OnCreated();
	}
	
	public goclassingcom(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) : 
			base(connection, mappingSource, sqlDialect)
	{
		this.OnCreated();
	}
}
#region End Not MONO_STRICT
	#endregion
#endif     // MONO_STRICT
#endregion

[Table(Name="goclassing_com.activity")]
public partial class activity : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private string _content;
	
	private int _id;
	
	private bool _pushed;
	
	private System.DateTime _time;
	
	private int _userid;
	
	private EntityRef<user> _user = new EntityRef<user>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OncontentChanged();
		
		partial void OncontentChanging(string value);
		
		partial void OnidChanged();
		
		partial void OnidChanging(int value);
		
		partial void OnpushedChanged();
		
		partial void OnpushedChanging(bool value);
		
		partial void OntimeChanged();
		
		partial void OntimeChanging(System.DateTime value);
		
		partial void OnuseridChanged();
		
		partial void OnuseridChanging(int value);
		#endregion
	
	
	public activity()
	{
		this.OnCreated();
	}
	
	[Column(Storage="_content", Name="content", DbType="varchar(500)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string content
	{
		get
		{
			return this._content;
		}
		set
		{
			if (((_content == value) 
						== false))
			{
				this.OncontentChanging(value);
				this.SendPropertyChanging();
				this._content = value;
				this.SendPropertyChanged("content");
				this.OncontentChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[Column(Storage="_pushed", Name="pushed", DbType="bit(1)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public bool pushed
	{
		get
		{
			return this._pushed;
		}
		set
		{
			if ((_pushed != value))
			{
				this.OnpushedChanging(value);
				this.SendPropertyChanging();
				this._pushed = value;
				this.SendPropertyChanged("pushed");
				this.OnpushedChanged();
			}
		}
	}
	
	[Column(Storage="_time", Name="time", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public System.DateTime time
	{
		get
		{
			return this._time;
		}
		set
		{
			if ((_time != value))
			{
				this.OntimeChanging(value);
				this.SendPropertyChanging();
				this._time = value;
				this.SendPropertyChanged("time");
				this.OntimeChanged();
			}
		}
	}
	
	[Column(Storage="_userid", Name="user_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int userid
	{
		get
		{
			return this._userid;
		}
		set
		{
			if ((_userid != value))
			{
				this.OnuseridChanging(value);
				this.SendPropertyChanging();
				this._userid = value;
				this.SendPropertyChanged("userid");
				this.OnuseridChanged();
			}
		}
	}
	
	#region Parents
	[Association(Storage="_user", OtherKey="id", ThisKey="userid", Name="activity_ibfk_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public user user
	{
		get
		{
			return this._user.Entity;
		}
		set
		{
			if (((this._user.Entity == value) 
						== false))
			{
				if ((this._user.Entity != null))
				{
					user previoususer = this._user.Entity;
					this._user.Entity = null;
					previoususer.activities.Remove(this);
				}
				this._user.Entity = value;
				if ((value != null))
				{
					value.activities.Add(this);
					_userid = value.id;
				}
				else
				{
					_userid = default(int);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
}

[Table(Name="goclassing_com.course")]
public partial class course : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private System.DateTime _createTime;
	
	private int _createuserid;
	
	private string _desc;
	
	private string _home;
	
	private string _id;
	
	private bool _pub;
	
	private string _title;
	
	private EntitySet<joining> _joining;
	
	private EntitySet<tag> _tags;
	
	private EntitySet<type> _types;
	
	private EntityRef<user> _user = new EntityRef<user>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OncreateTimeChanged();
		
		partial void OncreateTimeChanging(System.DateTime value);
		
		partial void OncreateuseridChanged();
		
		partial void OncreateuseridChanging(int value);
		
		partial void OndescChanged();
		
		partial void OndescChanging(string value);
		
		partial void OnhomeChanged();
		
		partial void OnhomeChanging(string value);
		
		partial void OnidChanged();
		
		partial void OnidChanging(string value);
		
		partial void OnpubChanged();
		
		partial void OnpubChanging(bool value);
		
		partial void OntitleChanged();
		
		partial void OntitleChanging(string value);
		#endregion
	
	
	public course()
	{
		_joining = new EntitySet<joining>(new Action<joining>(this.joining_Attach), new Action<joining>(this.joining_Detach));
		_tags = new EntitySet<tag>(new Action<tag>(this.tags_Attach), new Action<tag>(this.tags_Detach));
		_types = new EntitySet<type>(new Action<type>(this.types_Attach), new Action<type>(this.types_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_createTime", Name="createTime", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public System.DateTime createTime
	{
		get
		{
			return this._createTime;
		}
		set
		{
			if ((_createTime != value))
			{
				this.OncreateTimeChanging(value);
				this.SendPropertyChanging();
				this._createTime = value;
				this.SendPropertyChanged("createTime");
				this.OncreateTimeChanged();
			}
		}
	}
	
	[Column(Storage="_createuserid", Name="create_user_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int createuserid
	{
		get
		{
			return this._createuserid;
		}
		set
		{
			if ((_createuserid != value))
			{
				this.OncreateuseridChanging(value);
				this.SendPropertyChanging();
				this._createuserid = value;
				this.SendPropertyChanged("createuserid");
				this.OncreateuseridChanged();
			}
		}
	}
	
	[Column(Storage="_desc", Name="desc", DbType="varchar(1000)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string desc
	{
		get
		{
			return this._desc;
		}
		set
		{
			if (((_desc == value) 
						== false))
			{
				this.OndescChanging(value);
				this.SendPropertyChanging();
				this._desc = value;
				this.SendPropertyChanged("desc");
				this.OndescChanged();
			}
		}
	}
	
	[Column(Storage="_home", Name="home", DbType="varchar(10000)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string home
	{
		get
		{
			return this._home;
		}
		set
		{
			if (((_home == value) 
						== false))
			{
				this.OnhomeChanging(value);
				this.SendPropertyChanging();
				this._home = value;
				this.SendPropertyChanged("home");
				this.OnhomeChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="id", DbType="varchar(30)", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string id
	{
		get
		{
			return this._id;
		}
		set
		{
			if (((_id == value) 
						== false))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[Column(Storage="_pub", Name="pub", DbType="bit(1)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public bool pub
	{
		get
		{
			return this._pub;
		}
		set
		{
			if ((_pub != value))
			{
				this.OnpubChanging(value);
				this.SendPropertyChanging();
				this._pub = value;
				this.SendPropertyChanged("pub");
				this.OnpubChanged();
			}
		}
	}
	
	[Column(Storage="_title", Name="title", DbType="varchar(30)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string title
	{
		get
		{
			return this._title;
		}
		set
		{
			if (((_title == value) 
						== false))
			{
				this.OntitleChanging(value);
				this.SendPropertyChanging();
				this._title = value;
				this.SendPropertyChanged("title");
				this.OntitleChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_joining", OtherKey="courseid", ThisKey="id", Name="joining_ibfk_2")]
	[DebuggerNonUserCode()]
	public EntitySet<joining> joining
	{
		get
		{
			return this._joining;
		}
		set
		{
			this._joining = value;
		}
	}
	
	[Association(Storage="_tags", OtherKey="courseid", ThisKey="id", Name="tag_ibfk_1")]
	[DebuggerNonUserCode()]
	public EntitySet<tag> tags
	{
		get
		{
			return this._tags;
		}
		set
		{
			this._tags = value;
		}
	}
	
	[Association(Storage="_types", OtherKey="courseid", ThisKey="id", Name="type_ibfk_1")]
	[DebuggerNonUserCode()]
	public EntitySet<type> types
	{
		get
		{
			return this._types;
		}
		set
		{
			this._types = value;
		}
	}
	#endregion
	
	#region Parents
	[Association(Storage="_user", OtherKey="id", ThisKey="createuserid", Name="course_ibfk_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public user user
	{
		get
		{
			return this._user.Entity;
		}
		set
		{
			if (((this._user.Entity == value) 
						== false))
			{
				if ((this._user.Entity != null))
				{
					user previoususer = this._user.Entity;
					this._user.Entity = null;
					previoususer.courses.Remove(this);
				}
				this._user.Entity = value;
				if ((value != null))
				{
					value.courses.Add(this);
					_createuserid = value.id;
				}
				else
				{
					_createuserid = default(int);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void joining_Attach(joining entity)
	{
		this.SendPropertyChanging();
		entity.course = this;
	}
	
	private void joining_Detach(joining entity)
	{
		this.SendPropertyChanging();
		entity.course = null;
	}
	
	private void tags_Attach(tag entity)
	{
		this.SendPropertyChanging();
		entity.course = this;
	}
	
	private void tags_Detach(tag entity)
	{
		this.SendPropertyChanging();
		entity.course = null;
	}
	
	private void types_Attach(type entity)
	{
		this.SendPropertyChanging();
		entity.course = this;
	}
	
	private void types_Detach(type entity)
	{
		this.SendPropertyChanging();
		entity.course = null;
	}
	#endregion
}

[Table(Name="goclassing_com.doc")]
public partial class doc : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private string _content;
	
	private string _desc;
	
	private string _ext;
	
	private int _id;
	
	private int _sort;
	
	private System.DateTime _time;
	
	private string _title;
	
	private int _typeid;
	
	private string _uploadsecret;
	
	private EntitySet<reply> _replies;
	
	private EntityRef<type> _type = new EntityRef<type>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OncontentChanged();
		
		partial void OncontentChanging(string value);
		
		partial void OndescChanged();
		
		partial void OndescChanging(string value);
		
		partial void OnextChanged();
		
		partial void OnextChanging(string value);
		
		partial void OnidChanged();
		
		partial void OnidChanging(int value);
		
		partial void OnsortChanged();
		
		partial void OnsortChanging(int value);
		
		partial void OntimeChanged();
		
		partial void OntimeChanging(System.DateTime value);
		
		partial void OntitleChanged();
		
		partial void OntitleChanging(string value);
		
		partial void OntypeidChanged();
		
		partial void OntypeidChanging(int value);
		
		partial void OnuploadsecretChanged();
		
		partial void OnuploadsecretChanging(string value);
		#endregion
	
	
	public doc()
	{
		_replies = new EntitySet<reply>(new Action<reply>(this.replies_Attach), new Action<reply>(this.replies_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_content", Name="content", DbType="varchar(10000)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string content
	{
		get
		{
			return this._content;
		}
		set
		{
			if (((_content == value) 
						== false))
			{
				this.OncontentChanging(value);
				this.SendPropertyChanging();
				this._content = value;
				this.SendPropertyChanged("content");
				this.OncontentChanged();
			}
		}
	}
	
	[Column(Storage="_desc", Name="desc", DbType="varchar(1000)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string desc
	{
		get
		{
			return this._desc;
		}
		set
		{
			if (((_desc == value) 
						== false))
			{
				this.OndescChanging(value);
				this.SendPropertyChanging();
				this._desc = value;
				this.SendPropertyChanged("desc");
				this.OndescChanged();
			}
		}
	}
	
	[Column(Storage="_ext", Name="ext", DbType="varchar(10)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string ext
	{
		get
		{
			return this._ext;
		}
		set
		{
			if (((_ext == value) 
						== false))
			{
				this.OnextChanging(value);
				this.SendPropertyChanging();
				this._ext = value;
				this.SendPropertyChanged("ext");
				this.OnextChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[Column(Storage="_sort", Name="sort", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int sort
	{
		get
		{
			return this._sort;
		}
		set
		{
			if ((_sort != value))
			{
				this.OnsortChanging(value);
				this.SendPropertyChanging();
				this._sort = value;
				this.SendPropertyChanged("sort");
				this.OnsortChanged();
			}
		}
	}
	
	[Column(Storage="_time", Name="time", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public System.DateTime time
	{
		get
		{
			return this._time;
		}
		set
		{
			if ((_time != value))
			{
				this.OntimeChanging(value);
				this.SendPropertyChanging();
				this._time = value;
				this.SendPropertyChanged("time");
				this.OntimeChanged();
			}
		}
	}
	
	[Column(Storage="_title", Name="title", DbType="varchar(50)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string title
	{
		get
		{
			return this._title;
		}
		set
		{
			if (((_title == value) 
						== false))
			{
				this.OntitleChanging(value);
				this.SendPropertyChanging();
				this._title = value;
				this.SendPropertyChanged("title");
				this.OntitleChanged();
			}
		}
	}
	
	[Column(Storage="_typeid", Name="type_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int typeid
	{
		get
		{
			return this._typeid;
		}
		set
		{
			if ((_typeid != value))
			{
				this.OntypeidChanging(value);
				this.SendPropertyChanging();
				this._typeid = value;
				this.SendPropertyChanged("typeid");
				this.OntypeidChanged();
			}
		}
	}
	
	[Column(Storage="_uploadsecret", Name="upload_secret", DbType="varchar(33)", AutoSync=AutoSync.Never)]
	[DebuggerNonUserCode()]
	public string uploadsecret
	{
		get
		{
			return this._uploadsecret;
		}
		set
		{
			if (((_uploadsecret == value) 
						== false))
			{
				this.OnuploadsecretChanging(value);
				this.SendPropertyChanging();
				this._uploadsecret = value;
				this.SendPropertyChanged("uploadsecret");
				this.OnuploadsecretChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_replies", OtherKey="docid", ThisKey="id", Name="reply_ibfk_2")]
	[DebuggerNonUserCode()]
	public EntitySet<reply> replies
	{
		get
		{
			return this._replies;
		}
		set
		{
			this._replies = value;
		}
	}
	#endregion
	
	#region Parents
	[Association(Storage="_type", OtherKey="id", ThisKey="typeid", Name="doc_ibfk_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public type type
	{
		get
		{
			return this._type.Entity;
		}
		set
		{
			if (((this._type.Entity == value) 
						== false))
			{
				if ((this._type.Entity != null))
				{
					type previoustype = this._type.Entity;
					this._type.Entity = null;
					previoustype.doc.Remove(this);
				}
				this._type.Entity = value;
				if ((value != null))
				{
					value.doc.Add(this);
					_typeid = value.id;
				}
				else
				{
					_typeid = default(int);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void replies_Attach(reply entity)
	{
		this.SendPropertyChanging();
		entity.doc = this;
	}
	
	private void replies_Detach(reply entity)
	{
		this.SendPropertyChanging();
		entity.doc = null;
	}
	#endregion
}

[Table(Name="goclassing_com.joining")]
public partial class joining : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private bool _aprooved;
	
	private string _courseid;
	
	private int _id;
	
	private string _userusername;
	
	private EntityRef<course> _course = new EntityRef<course>();
	
	private EntityRef<user> _user = new EntityRef<user>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnaproovedChanged();
		
		partial void OnaproovedChanging(bool value);
		
		partial void OncourseidChanged();
		
		partial void OncourseidChanging(string value);
		
		partial void OnidChanged();
		
		partial void OnidChanging(int value);
		
		partial void OnuserusernameChanged();
		
		partial void OnuserusernameChanging(string value);
		#endregion
	
	
	public joining()
	{
		this.OnCreated();
	}
	
	[Column(Storage="_aprooved", Name="aprooved", DbType="bit(1)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public bool aprooved
	{
		get
		{
			return this._aprooved;
		}
		set
		{
			if ((_aprooved != value))
			{
				this.OnaproovedChanging(value);
				this.SendPropertyChanging();
				this._aprooved = value;
				this.SendPropertyChanged("aprooved");
				this.OnaproovedChanged();
			}
		}
	}
	
	[Column(Storage="_courseid", Name="course_id", DbType="varchar(30)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string courseid
	{
		get
		{
			return this._courseid;
		}
		set
		{
			if (((_courseid == value) 
						== false))
			{
				this.OncourseidChanging(value);
				this.SendPropertyChanging();
				this._courseid = value;
				this.SendPropertyChanged("courseid");
				this.OncourseidChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[Column(Storage="_userusername", Name="user_username", DbType="varchar(50)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string userusername
	{
		get
		{
			return this._userusername;
		}
		set
		{
			if (((_userusername == value) 
						== false))
			{
				this.OnuserusernameChanging(value);
				this.SendPropertyChanging();
				this._userusername = value;
				this.SendPropertyChanged("userusername");
				this.OnuserusernameChanged();
			}
		}
	}
	
	#region Parents
	[Association(Storage="_course", OtherKey="id", ThisKey="courseid", Name="joining_ibfk_2", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public course course
	{
		get
		{
			return this._course.Entity;
		}
		set
		{
			if (((this._course.Entity == value) 
						== false))
			{
				if ((this._course.Entity != null))
				{
					course previouscourse = this._course.Entity;
					this._course.Entity = null;
					previouscourse.joining.Remove(this);
				}
				this._course.Entity = value;
				if ((value != null))
				{
					value.joining.Add(this);
					_courseid = value.id;
				}
				else
				{
					_courseid = default(string);
				}
			}
		}
	}
	
	[Association(Storage="_user", OtherKey="username", ThisKey="userusername", Name="joining_ibfk_3", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public user user
	{
		get
		{
			return this._user.Entity;
		}
		set
		{
			if (((this._user.Entity == value) 
						== false))
			{
				if ((this._user.Entity != null))
				{
					user previoususer = this._user.Entity;
					this._user.Entity = null;
					previoususer.joining.Remove(this);
				}
				this._user.Entity = value;
				if ((value != null))
				{
					value.joining.Add(this);
					_userusername = value.username;
				}
				else
				{
					_userusername = default(string);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
}

[Table(Name="goclassing_com.reply")]
public partial class reply : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private string _content;
	
	private int _docid;
	
	private int _fromuserid;
	
	private int _id;
	
	private System.DateTime _time;
	
	private EntityRef<user> _user = new EntityRef<user>();
	
	private EntityRef<doc> _doc = new EntityRef<doc>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OncontentChanged();
		
		partial void OncontentChanging(string value);
		
		partial void OndocidChanged();
		
		partial void OndocidChanging(int value);
		
		partial void OnfromuseridChanged();
		
		partial void OnfromuseridChanging(int value);
		
		partial void OnidChanged();
		
		partial void OnidChanging(int value);
		
		partial void OntimeChanged();
		
		partial void OntimeChanging(System.DateTime value);
		#endregion
	
	
	public reply()
	{
		this.OnCreated();
	}
	
	[Column(Storage="_content", Name="content", DbType="varchar(1000)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string content
	{
		get
		{
			return this._content;
		}
		set
		{
			if (((_content == value) 
						== false))
			{
				this.OncontentChanging(value);
				this.SendPropertyChanging();
				this._content = value;
				this.SendPropertyChanged("content");
				this.OncontentChanged();
			}
		}
	}
	
	[Column(Storage="_docid", Name="doc_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int docid
	{
		get
		{
			return this._docid;
		}
		set
		{
			if ((_docid != value))
			{
				this.OndocidChanging(value);
				this.SendPropertyChanging();
				this._docid = value;
				this.SendPropertyChanged("docid");
				this.OndocidChanged();
			}
		}
	}
	
	[Column(Storage="_fromuserid", Name="from_user_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int fromuserid
	{
		get
		{
			return this._fromuserid;
		}
		set
		{
			if ((_fromuserid != value))
			{
				this.OnfromuseridChanging(value);
				this.SendPropertyChanging();
				this._fromuserid = value;
				this.SendPropertyChanged("fromuserid");
				this.OnfromuseridChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[Column(Storage="_time", Name="time", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public System.DateTime time
	{
		get
		{
			return this._time;
		}
		set
		{
			if ((_time != value))
			{
				this.OntimeChanging(value);
				this.SendPropertyChanging();
				this._time = value;
				this.SendPropertyChanged("time");
				this.OntimeChanged();
			}
		}
	}
	
	#region Parents
	[Association(Storage="_user", OtherKey="id", ThisKey="fromuserid", Name="reply_ibfk_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public user user
	{
		get
		{
			return this._user.Entity;
		}
		set
		{
			if (((this._user.Entity == value) 
						== false))
			{
				if ((this._user.Entity != null))
				{
					user previoususer = this._user.Entity;
					this._user.Entity = null;
					previoususer.replies.Remove(this);
				}
				this._user.Entity = value;
				if ((value != null))
				{
					value.replies.Add(this);
					_fromuserid = value.id;
				}
				else
				{
					_fromuserid = default(int);
				}
			}
		}
	}
	
	[Association(Storage="_doc", OtherKey="id", ThisKey="docid", Name="reply_ibfk_2", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public doc doc
	{
		get
		{
			return this._doc.Entity;
		}
		set
		{
			if (((this._doc.Entity == value) 
						== false))
			{
				if ((this._doc.Entity != null))
				{
					doc previousdoc = this._doc.Entity;
					this._doc.Entity = null;
					previousdoc.replies.Remove(this);
				}
				this._doc.Entity = value;
				if ((value != null))
				{
					value.replies.Add(this);
					_docid = value.id;
				}
				else
				{
					_docid = default(int);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
}

[Table(Name="goclassing_com.secret")]
public partial class secret : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private string _authToken;
	
	private System.DateTime _authTokenExpire;
	
	private string _data;
	
	private int _id;
	
	private int _logon;
	
	private int _userid;
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnauthTokenChanged();
		
		partial void OnauthTokenChanging(string value);
		
		partial void OnauthTokenExpireChanged();
		
		partial void OnauthTokenExpireChanging(System.DateTime value);
		
		partial void OndataChanged();
		
		partial void OndataChanging(string value);
		
		partial void OnidChanged();
		
		partial void OnidChanging(int value);
		
		partial void OnlogonChanged();
		
		partial void OnlogonChanging(int value);
		
		partial void OnuseridChanged();
		
		partial void OnuseridChanging(int value);
		#endregion
	
	
	public secret()
	{
		this.OnCreated();
	}
	
	[Column(Storage="_authToken", Name="authToken", DbType="varchar(200)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string authToken
	{
		get
		{
			return this._authToken;
		}
		set
		{
			if (((_authToken == value) 
						== false))
			{
				this.OnauthTokenChanging(value);
				this.SendPropertyChanging();
				this._authToken = value;
				this.SendPropertyChanged("authToken");
				this.OnauthTokenChanged();
			}
		}
	}
	
	[Column(Storage="_authTokenExpire", Name="authTokenExpire", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public System.DateTime authTokenExpire
	{
		get
		{
			return this._authTokenExpire;
		}
		set
		{
			if ((_authTokenExpire != value))
			{
				this.OnauthTokenExpireChanging(value);
				this.SendPropertyChanging();
				this._authTokenExpire = value;
				this.SendPropertyChanged("authTokenExpire");
				this.OnauthTokenExpireChanged();
			}
		}
	}
	
	[Column(Storage="_data", Name="data", DbType="varchar(200)", AutoSync=AutoSync.Never)]
	[DebuggerNonUserCode()]
	public string data
	{
		get
		{
			return this._data;
		}
		set
		{
			if (((_data == value) 
						== false))
			{
				this.OndataChanging(value);
				this.SendPropertyChanging();
				this._data = value;
				this.SendPropertyChanged("data");
				this.OndataChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[Column(Storage="_logon", Name="logon", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int logon
	{
		get
		{
			return this._logon;
		}
		set
		{
			if ((_logon != value))
			{
				this.OnlogonChanging(value);
				this.SendPropertyChanging();
				this._logon = value;
				this.SendPropertyChanged("logon");
				this.OnlogonChanged();
			}
		}
	}
	
	[Column(Storage="_userid", Name="user_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int userid
	{
		get
		{
			return this._userid;
		}
		set
		{
			if ((_userid != value))
			{
				this.OnuseridChanging(value);
				this.SendPropertyChanging();
				this._userid = value;
				this.SendPropertyChanged("userid");
				this.OnuseridChanged();
			}
		}
	}
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
}

[Table(Name="goclassing_com.tag")]
public partial class tag : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private string _courseid;
	
	private int _id;
	
	private string _value;
	
	private EntityRef<course> _course = new EntityRef<course>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OncourseidChanged();
		
		partial void OncourseidChanging(string value);
		
		partial void OnidChanged();
		
		partial void OnidChanging(int value);
		
		partial void OnvalueChanged();
		
		partial void OnvalueChanging(string value);
		#endregion
	
	
	public tag()
	{
		this.OnCreated();
	}
	
	[Column(Storage="_courseid", Name="course_id", DbType="varchar(30)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string courseid
	{
		get
		{
			return this._courseid;
		}
		set
		{
			if (((_courseid == value) 
						== false))
			{
				this.OncourseidChanging(value);
				this.SendPropertyChanging();
				this._courseid = value;
				this.SendPropertyChanged("courseid");
				this.OncourseidChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[Column(Storage="_value", Name="value", DbType="varchar(10)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string value
	{
		get
		{
			return this._value;
		}
		set
		{
			if (((_value == value) 
						== false))
			{
				this.OnvalueChanging(value);
				this.SendPropertyChanging();
				this._value = value;
				this.SendPropertyChanged("value");
				this.OnvalueChanged();
			}
		}
	}
	
	#region Parents
	[Association(Storage="_course", OtherKey="id", ThisKey="courseid", Name="tag_ibfk_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public course course
	{
		get
		{
			return this._course.Entity;
		}
		set
		{
			if (((this._course.Entity == value) 
						== false))
			{
				if ((this._course.Entity != null))
				{
					course previouscourse = this._course.Entity;
					this._course.Entity = null;
					previouscourse.tags.Remove(this);
				}
				this._course.Entity = value;
				if ((value != null))
				{
					value.tags.Add(this);
					_courseid = value.id;
				}
				else
				{
					_courseid = default(string);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
}

[Table(Name="goclassing_com.type")]
public partial class type : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private string _courseid;
	
	private int _id;
	
	private bool _public;
	
	private int _sort;
	
	private string _title;
	
	private EntitySet<doc> _doc;
	
	private EntityRef<course> _course = new EntityRef<course>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OncourseidChanged();
		
		partial void OncourseidChanging(string value);
		
		partial void OnidChanged();
		
		partial void OnidChanging(int value);
		
		partial void OnpublicChanged();
		
		partial void OnpublicChanging(bool value);
		
		partial void OnsortChanged();
		
		partial void OnsortChanging(int value);
		
		partial void OntitleChanged();
		
		partial void OntitleChanging(string value);
		#endregion
	
	
	public type()
	{
		_doc = new EntitySet<doc>(new Action<doc>(this.doc_Attach), new Action<doc>(this.doc_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_courseid", Name="course_id", DbType="varchar(30)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string courseid
	{
		get
		{
			return this._courseid;
		}
		set
		{
			if (((_courseid == value) 
						== false))
			{
				this.OncourseidChanging(value);
				this.SendPropertyChanging();
				this._courseid = value;
				this.SendPropertyChanged("courseid");
				this.OncourseidChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[Column(Storage="_public", Name="public", DbType="bit(1)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public bool @public
	{
		get
		{
			return this._public;
		}
		set
		{
			if ((_public != value))
			{
				this.OnpublicChanging(value);
				this.SendPropertyChanging();
				this._public = value;
				this.SendPropertyChanged("public");
				this.OnpublicChanged();
			}
		}
	}
	
	[Column(Storage="_sort", Name="sort", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int sort
	{
		get
		{
			return this._sort;
		}
		set
		{
			if ((_sort != value))
			{
				this.OnsortChanging(value);
				this.SendPropertyChanging();
				this._sort = value;
				this.SendPropertyChanged("sort");
				this.OnsortChanged();
			}
		}
	}
	
	[Column(Storage="_title", Name="title", DbType="varchar(50)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string title
	{
		get
		{
			return this._title;
		}
		set
		{
			if (((_title == value) 
						== false))
			{
				this.OntitleChanging(value);
				this.SendPropertyChanging();
				this._title = value;
				this.SendPropertyChanged("title");
				this.OntitleChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_doc", OtherKey="typeid", ThisKey="id", Name="doc_ibfk_1")]
	[DebuggerNonUserCode()]
	public EntitySet<doc> doc
	{
		get
		{
			return this._doc;
		}
		set
		{
			this._doc = value;
		}
	}
	#endregion
	
	#region Parents
	[Association(Storage="_course", OtherKey="id", ThisKey="courseid", Name="type_ibfk_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public course course
	{
		get
		{
			return this._course.Entity;
		}
		set
		{
			if (((this._course.Entity == value) 
						== false))
			{
				if ((this._course.Entity != null))
				{
					course previouscourse = this._course.Entity;
					this._course.Entity = null;
					previouscourse.types.Remove(this);
				}
				this._course.Entity = value;
				if ((value != null))
				{
					value.types.Add(this);
					_courseid = value.id;
				}
				else
				{
					_courseid = default(string);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void doc_Attach(doc entity)
	{
		this.SendPropertyChanging();
		entity.type = this;
	}
	
	private void doc_Detach(doc entity)
	{
		this.SendPropertyChanging();
		entity.type = null;
	}
	#endregion
}

[Table(Name="goclassing_com.user")]
public partial class user : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private string _authID;
	
	private string _authProvider;
	
	private string _avatarUrl;
	
	private string _gender;
	
	private int _id;
	
	private string _name;
	
	private System.Nullable<int> _replyTo;
	
	private string _username;
	
	private EntitySet<activity> _activities;
	
	private EntitySet<course> _courses;
	
	private EntitySet<joining> _joining;
	
	private EntitySet<reply> _replies;
	
	private EntitySet<user> _users;
	
	private EntityRef<user> _replyTouser = new EntityRef<user>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnauthIdChanged();
		
		partial void OnauthIdChanging(string value);
		
		partial void OnauthProviderChanged();
		
		partial void OnauthProviderChanging(string value);
		
		partial void OnavatarUrlChanged();
		
		partial void OnavatarUrlChanging(string value);
		
		partial void OngenderChanged();
		
		partial void OngenderChanging(string value);
		
		partial void OnidChanged();
		
		partial void OnidChanging(int value);
		
		partial void OnnameChanged();
		
		partial void OnnameChanging(string value);
		
		partial void OnreplyToChanged();
		
		partial void OnreplyToChanging(System.Nullable<int> value);
		
		partial void OnusernameChanged();
		
		partial void OnusernameChanging(string value);
		#endregion
	
	
	public user()
	{
		_activities = new EntitySet<activity>(new Action<activity>(this.activities_Attach), new Action<activity>(this.activities_Detach));
		_courses = new EntitySet<course>(new Action<course>(this.courses_Attach), new Action<course>(this.courses_Detach));
		_joining = new EntitySet<joining>(new Action<joining>(this.joining_Attach), new Action<joining>(this.joining_Detach));
		_replies = new EntitySet<reply>(new Action<reply>(this.replies_Attach), new Action<reply>(this.replies_Detach));
		_users = new EntitySet<user>(new Action<user>(this.users_Attach), new Action<user>(this.users_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_authID", Name="authId", DbType="varchar(30)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string authId
	{
		get
		{
			return this._authID;
		}
		set
		{
			if (((_authID == value) 
						== false))
			{
				this.OnauthIdChanging(value);
				this.SendPropertyChanging();
				this._authID = value;
				this.SendPropertyChanged("authId");
				this.OnauthIdChanged();
			}
		}
	}
	
	[Column(Storage="_authProvider", Name="authProvider", DbType="varchar(15)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string authProvider
	{
		get
		{
			return this._authProvider;
		}
		set
		{
			if (((_authProvider == value) 
						== false))
			{
				this.OnauthProviderChanging(value);
				this.SendPropertyChanging();
				this._authProvider = value;
				this.SendPropertyChanged("authProvider");
				this.OnauthProviderChanged();
			}
		}
	}
	
	[Column(Storage="_avatarUrl", Name="avatarUrl", DbType="varchar(200)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string avatarUrl
	{
		get
		{
			return this._avatarUrl;
		}
		set
		{
			if (((_avatarUrl == value) 
						== false))
			{
				this.OnavatarUrlChanging(value);
				this.SendPropertyChanging();
				this._avatarUrl = value;
				this.SendPropertyChanged("avatarUrl");
				this.OnavatarUrlChanged();
			}
		}
	}
	
	[Column(Storage="_gender", Name="gender", DbType="varchar(10)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string gender
	{
		get
		{
			return this._gender;
		}
		set
		{
			if (((_gender == value) 
						== false))
			{
				this.OngenderChanging(value);
				this.SendPropertyChanging();
				this._gender = value;
				this.SendPropertyChanged("gender");
				this.OngenderChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[Column(Storage="_name", Name="name", DbType="varchar(30)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string name
	{
		get
		{
			return this._name;
		}
		set
		{
			if (((_name == value) 
						== false))
			{
				this.OnnameChanging(value);
				this.SendPropertyChanging();
				this._name = value;
				this.SendPropertyChanged("name");
				this.OnnameChanged();
			}
		}
	}
	
	[Column(Storage="_replyTo", Name="replyTo", DbType="int", AutoSync=AutoSync.Never)]
	[DebuggerNonUserCode()]
	public System.Nullable<int> replyTo
	{
		get
		{
			return this._replyTo;
		}
		set
		{
			if ((_replyTo != value))
			{
				if (_replyTouser.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnreplyToChanging(value);
				this.SendPropertyChanging();
				this._replyTo = value;
				this.SendPropertyChanged("replyTo");
				this.OnreplyToChanged();
			}
		}
	}
	
	[Column(Storage="_username", Name="username", DbType="varchar(50)", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string username
	{
		get
		{
			return this._username;
		}
		set
		{
			if (((_username == value) 
						== false))
			{
				this.OnusernameChanging(value);
				this.SendPropertyChanging();
				this._username = value;
				this.SendPropertyChanged("username");
				this.OnusernameChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_activities", OtherKey="userid", ThisKey="id", Name="activity_ibfk_1")]
	[DebuggerNonUserCode()]
	public EntitySet<activity> activities
	{
		get
		{
			return this._activities;
		}
		set
		{
			this._activities = value;
		}
	}
	
	[Association(Storage="_courses", OtherKey="createuserid", ThisKey="id", Name="course_ibfk_1")]
	[DebuggerNonUserCode()]
	public EntitySet<course> courses
	{
		get
		{
			return this._courses;
		}
		set
		{
			this._courses = value;
		}
	}
	
	[Association(Storage="_joining", OtherKey="userusername", ThisKey="username", Name="joining_ibfk_3")]
	[DebuggerNonUserCode()]
	public EntitySet<joining> joining
	{
		get
		{
			return this._joining;
		}
		set
		{
			this._joining = value;
		}
	}
	
	[Association(Storage="_replies", OtherKey="fromuserid", ThisKey="id", Name="reply_ibfk_1")]
	[DebuggerNonUserCode()]
	public EntitySet<reply> replies
	{
		get
		{
			return this._replies;
		}
		set
		{
			this._replies = value;
		}
	}
	
	[Association(Storage="_users", OtherKey="replyTo", ThisKey="id", Name="user_ibfk_1")]
	[DebuggerNonUserCode()]
	public EntitySet<user> users
	{
		get
		{
			return this._users;
		}
		set
		{
			this._users = value;
		}
	}
	#endregion
	
	#region Parents
	[Association(Storage="_replyTouser", OtherKey="id", ThisKey="replyTo", Name="user_ibfk_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public user replyTouser
	{
		get
		{
			return this._replyTouser.Entity;
		}
		set
		{
			if (((this._replyTouser.Entity == value) 
						== false))
			{
				if ((this._replyTouser.Entity != null))
				{
					user previoususer = this._replyTouser.Entity;
					this._replyTouser.Entity = null;
					previoususer.users.Remove(this);
				}
				this._replyTouser.Entity = value;
				if ((value != null))
				{
					value.users.Add(this);
					_replyTo = value.id;
				}
				else
				{
					_replyTo = null;
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void activities_Attach(activity entity)
	{
		this.SendPropertyChanging();
		entity.user = this;
	}
	
	private void activities_Detach(activity entity)
	{
		this.SendPropertyChanging();
		entity.user = null;
	}
	
	private void courses_Attach(course entity)
	{
		this.SendPropertyChanging();
		entity.user = this;
	}
	
	private void courses_Detach(course entity)
	{
		this.SendPropertyChanging();
		entity.user = null;
	}
	
	private void joining_Attach(joining entity)
	{
		this.SendPropertyChanging();
		entity.user = this;
	}
	
	private void joining_Detach(joining entity)
	{
		this.SendPropertyChanging();
		entity.user = null;
	}
	
	private void replies_Attach(reply entity)
	{
		this.SendPropertyChanging();
		entity.user = this;
	}
	
	private void replies_Detach(reply entity)
	{
		this.SendPropertyChanging();
		entity.user = null;
	}
	
	private void users_Attach(user entity)
	{
		this.SendPropertyChanging();
		entity.replyTouser = this;
	}
	
	private void users_Detach(user entity)
	{
		this.SendPropertyChanging();
		entity.replyTouser = null;
	}
	#endregion
}
