﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Emplokey
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Emplokey")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertComputer(Computer instance);
    partial void UpdateComputer(Computer instance);
    partial void DeleteComputer(Computer instance);
    partial void InsertAuth(Auth instance);
    partial void UpdateAuth(Auth instance);
    partial void DeleteAuth(Auth instance);
    partial void InsertLog(Log instance);
    partial void UpdateLog(Log instance);
    partial void DeleteLog(Log instance);
    partial void InsertRequest(Request instance);
    partial void UpdateRequest(Request instance);
    partial void DeleteRequest(Request instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::Emplokey.Properties.Settings.Default.EmplokeyConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Computer> Computers
		{
			get
			{
				return this.GetTable<Computer>();
			}
		}
		
		public System.Data.Linq.Table<Auth> Auths
		{
			get
			{
				return this.GetTable<Auth>();
			}
		}
		
		public System.Data.Linq.Table<Log> Logs
		{
			get
			{
				return this.GetTable<Log>();
			}
		}
		
		public System.Data.Linq.Table<Request> Requests
		{
			get
			{
				return this.GetTable<Request>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Username;
		
		private string _Type;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnTypeChanging(string value);
    partial void OnTypeChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="VarChar(50)")]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Computers")]
	public partial class Computer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _PC_name;
		
		private int _Lock_status;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnPC_nameChanging(string value);
    partial void OnPC_nameChanged();
    partial void OnLock_statusChanging(int value);
    partial void OnLock_statusChanged();
    #endregion
		
		public Computer()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PC_name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string PC_name
		{
			get
			{
				return this._PC_name;
			}
			set
			{
				if ((this._PC_name != value))
				{
					this.OnPC_nameChanging(value);
					this.SendPropertyChanging();
					this._PC_name = value;
					this.SendPropertyChanged("PC_name");
					this.OnPC_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Lock_status", DbType="Int NOT NULL")]
		public int Lock_status
		{
			get
			{
				return this._Lock_status;
			}
			set
			{
				if ((this._Lock_status != value))
				{
					this.OnLock_statusChanging(value);
					this.SendPropertyChanging();
					this._Lock_status = value;
					this.SendPropertyChanged("Lock_status");
					this.OnLock_statusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Auths")]
	public partial class Auth : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _ID_user;
		
		private int _ID_pc;
		
		private string _Auth_key;
		
		private string _Device;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnID_userChanging(int value);
    partial void OnID_userChanged();
    partial void OnID_pcChanging(int value);
    partial void OnID_pcChanged();
    partial void OnAuth_keyChanging(string value);
    partial void OnAuth_keyChanged();
    partial void OnDeviceChanging(string value);
    partial void OnDeviceChanged();
    #endregion
		
		public Auth()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_user", DbType="Int NOT NULL")]
		public int ID_user
		{
			get
			{
				return this._ID_user;
			}
			set
			{
				if ((this._ID_user != value))
				{
					this.OnID_userChanging(value);
					this.SendPropertyChanging();
					this._ID_user = value;
					this.SendPropertyChanged("ID_user");
					this.OnID_userChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_pc", DbType="Int NOT NULL")]
		public int ID_pc
		{
			get
			{
				return this._ID_pc;
			}
			set
			{
				if ((this._ID_pc != value))
				{
					this.OnID_pcChanging(value);
					this.SendPropertyChanging();
					this._ID_pc = value;
					this.SendPropertyChanged("ID_pc");
					this.OnID_pcChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Auth_key", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Auth_key
		{
			get
			{
				return this._Auth_key;
			}
			set
			{
				if ((this._Auth_key != value))
				{
					this.OnAuth_keyChanging(value);
					this.SendPropertyChanging();
					this._Auth_key = value;
					this.SendPropertyChanged("Auth_key");
					this.OnAuth_keyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Device", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Device
		{
			get
			{
				return this._Device;
			}
			set
			{
				if ((this._Device != value))
				{
					this.OnDeviceChanging(value);
					this.SendPropertyChanging();
					this._Device = value;
					this.SendPropertyChanged("Device");
					this.OnDeviceChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Logs")]
	public partial class Log : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _ID_user;
		
		private int _ID_pc;
		
		private System.DateTime _Time_login;
		
		private System.Nullable<System.DateTime> _Time_logout;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnID_userChanging(int value);
    partial void OnID_userChanged();
    partial void OnID_pcChanging(int value);
    partial void OnID_pcChanged();
    partial void OnTime_loginChanging(System.DateTime value);
    partial void OnTime_loginChanged();
    partial void OnTime_logoutChanging(System.Nullable<System.DateTime> value);
    partial void OnTime_logoutChanged();
    #endregion
		
		public Log()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_user", DbType="Int NOT NULL")]
		public int ID_user
		{
			get
			{
				return this._ID_user;
			}
			set
			{
				if ((this._ID_user != value))
				{
					this.OnID_userChanging(value);
					this.SendPropertyChanging();
					this._ID_user = value;
					this.SendPropertyChanged("ID_user");
					this.OnID_userChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_pc", DbType="Int NOT NULL")]
		public int ID_pc
		{
			get
			{
				return this._ID_pc;
			}
			set
			{
				if ((this._ID_pc != value))
				{
					this.OnID_pcChanging(value);
					this.SendPropertyChanging();
					this._ID_pc = value;
					this.SendPropertyChanged("ID_pc");
					this.OnID_pcChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Time_login", DbType="DateTime NOT NULL")]
		public System.DateTime Time_login
		{
			get
			{
				return this._Time_login;
			}
			set
			{
				if ((this._Time_login != value))
				{
					this.OnTime_loginChanging(value);
					this.SendPropertyChanging();
					this._Time_login = value;
					this.SendPropertyChanged("Time_login");
					this.OnTime_loginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Time_logout", DbType="DateTime")]
		public System.Nullable<System.DateTime> Time_logout
		{
			get
			{
				return this._Time_logout;
			}
			set
			{
				if ((this._Time_logout != value))
				{
					this.OnTime_logoutChanging(value);
					this.SendPropertyChanging();
					this._Time_logout = value;
					this.SendPropertyChanged("Time_logout");
					this.OnTime_logoutChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Requests")]
	public partial class Request : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _LogId;
		
		private int _Confirmed;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnLogIdChanging(int value);
    partial void OnLogIdChanged();
    partial void OnConfirmedChanging(int value);
    partial void OnConfirmedChanged();
    #endregion
		
		public Request()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogId", DbType="Int NOT NULL")]
		public int LogId
		{
			get
			{
				return this._LogId;
			}
			set
			{
				if ((this._LogId != value))
				{
					this.OnLogIdChanging(value);
					this.SendPropertyChanging();
					this._LogId = value;
					this.SendPropertyChanged("LogId");
					this.OnLogIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Confirmed", DbType="Int NOT NULL")]
		public int Confirmed
		{
			get
			{
				return this._Confirmed;
			}
			set
			{
				if ((this._Confirmed != value))
				{
					this.OnConfirmedChanging(value);
					this.SendPropertyChanging();
					this._Confirmed = value;
					this.SendPropertyChanged("Confirmed");
					this.OnConfirmedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
