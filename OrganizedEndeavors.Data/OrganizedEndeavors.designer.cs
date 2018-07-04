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

namespace OrganizedEndeavors.Data
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="OrganizedEndeavors")]
	public partial class OrganizedEndeavorsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertEndeavor(Endeavor instance);
    partial void UpdateEndeavor(Endeavor instance);
    partial void DeleteEndeavor(Endeavor instance);
    partial void InsertMember(Member instance);
    partial void UpdateMember(Member instance);
    partial void DeleteMember(Member instance);
    #endregion
		
		public OrganizedEndeavorsDataContext() : 
				base(global::OrganizedEndeavors.Data.Properties.Settings.Default.OrganizedEndeavorsConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public OrganizedEndeavorsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OrganizedEndeavorsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OrganizedEndeavorsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OrganizedEndeavorsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Endeavor> Endeavors
		{
			get
			{
				return this.GetTable<Endeavor>();
			}
		}
		
		public System.Data.Linq.Table<Member> Members
		{
			get
			{
				return this.GetTable<Member>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Endeavors")]
	public partial class Endeavor : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Endeavor1;
		
		private System.Nullable<int> _HandledBy;
		
		private bool _IsCompleted;
		
		private EntityRef<Member> _Member;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnEndeavor1Changing(string value);
    partial void OnEndeavor1Changed();
    partial void OnHandledByChanging(System.Nullable<int> value);
    partial void OnHandledByChanged();
    partial void OnIsCompletedChanging(bool value);
    partial void OnIsCompletedChanged();
    #endregion
		
		public Endeavor()
		{
			this._Member = default(EntityRef<Member>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Endeavor", Storage="_Endeavor1", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Endeavor1
		{
			get
			{
				return this._Endeavor1;
			}
			set
			{
				if ((this._Endeavor1 != value))
				{
					this.OnEndeavor1Changing(value);
					this.SendPropertyChanging();
					this._Endeavor1 = value;
					this.SendPropertyChanged("Endeavor1");
					this.OnEndeavor1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HandledBy", DbType="Int")]
		public System.Nullable<int> HandledBy
		{
			get
			{
				return this._HandledBy;
			}
			set
			{
				if ((this._HandledBy != value))
				{
					if (this._Member.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnHandledByChanging(value);
					this.SendPropertyChanging();
					this._HandledBy = value;
					this.SendPropertyChanged("HandledBy");
					this.OnHandledByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsCompleted", DbType="Bit NOT NULL")]
		public bool IsCompleted
		{
			get
			{
				return this._IsCompleted;
			}
			set
			{
				if ((this._IsCompleted != value))
				{
					this.OnIsCompletedChanging(value);
					this.SendPropertyChanging();
					this._IsCompleted = value;
					this.SendPropertyChanged("IsCompleted");
					this.OnIsCompletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Member_Endeavor", Storage="_Member", ThisKey="HandledBy", OtherKey="Id", IsForeignKey=true)]
		public Member Member
		{
			get
			{
				return this._Member.Entity;
			}
			set
			{
				Member previousValue = this._Member.Entity;
				if (((previousValue != value) 
							|| (this._Member.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Member.Entity = null;
						previousValue.Endeavors.Remove(this);
					}
					this._Member.Entity = value;
					if ((value != null))
					{
						value.Endeavors.Add(this);
						this._HandledBy = value.Id;
					}
					else
					{
						this._HandledBy = default(Nullable<int>);
					}
					this.SendPropertyChanged("Member");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Members")]
	public partial class Member : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private string _Email;
		
		private string _PasswordHash;
		
		private string _PasswordSalt;
		
		private EntitySet<Endeavor> _Endeavors;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordHashChanging(string value);
    partial void OnPasswordHashChanged();
    partial void OnPasswordSaltChanging(string value);
    partial void OnPasswordSaltChanged();
    #endregion
		
		public Member()
		{
			this._Endeavors = new EntitySet<Endeavor>(new Action<Endeavor>(this.attach_Endeavors), new Action<Endeavor>(this.detach_Endeavors));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PasswordHash", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string PasswordHash
		{
			get
			{
				return this._PasswordHash;
			}
			set
			{
				if ((this._PasswordHash != value))
				{
					this.OnPasswordHashChanging(value);
					this.SendPropertyChanging();
					this._PasswordHash = value;
					this.SendPropertyChanged("PasswordHash");
					this.OnPasswordHashChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PasswordSalt", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string PasswordSalt
		{
			get
			{
				return this._PasswordSalt;
			}
			set
			{
				if ((this._PasswordSalt != value))
				{
					this.OnPasswordSaltChanging(value);
					this.SendPropertyChanging();
					this._PasswordSalt = value;
					this.SendPropertyChanged("PasswordSalt");
					this.OnPasswordSaltChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Member_Endeavor", Storage="_Endeavors", ThisKey="Id", OtherKey="HandledBy")]
		public EntitySet<Endeavor> Endeavors
		{
			get
			{
				return this._Endeavors;
			}
			set
			{
				this._Endeavors.Assign(value);
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
		
		private void attach_Endeavors(Endeavor entity)
		{
			this.SendPropertyChanging();
			entity.Member = this;
		}
		
		private void detach_Endeavors(Endeavor entity)
		{
			this.SendPropertyChanging();
			entity.Member = null;
		}
	}
}
#pragma warning restore 1591