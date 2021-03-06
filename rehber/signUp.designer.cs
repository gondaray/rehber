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

namespace rehber
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="tokDB")]
	public partial class signUpDataContextDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertKullaniciKayit(KullaniciKayit instance);
    partial void UpdateKullaniciKayit(KullaniciKayit instance);
    partial void DeleteKullaniciKayit(KullaniciKayit instance);
    #endregion
		
		public signUpDataContextDataContext() : 
				base(global::rehber.Properties.Settings.Default.tokDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public signUpDataContextDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public signUpDataContextDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public signUpDataContextDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public signUpDataContextDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<KullaniciKayit> KullaniciKayits
		{
			get
			{
				return this.GetTable<KullaniciKayit>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.login")]
	public partial class KullaniciKayit : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _kullaniciID;
		
		private string _kullaniciAdi;
		
		private string _sifre;
		
		private string _kullaniciEmail;
		
		private bool _beniHatirla;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnkullaniciIDChanging(int value);
    partial void OnkullaniciIDChanged();
    partial void OnkullaniciAdiChanging(string value);
    partial void OnkullaniciAdiChanged();
    partial void OnsifreChanging(string value);
    partial void OnsifreChanged();
    partial void OnkullaniciEmailChanging(string value);
    partial void OnkullaniciEmailChanged();
    partial void OnbeniHatirlaChanging(bool value);
    partial void OnbeniHatirlaChanged();
    #endregion
		
		public KullaniciKayit()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kullaniciID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int kullaniciID
		{
			get
			{
				return this._kullaniciID;
			}
			set
			{
				if ((this._kullaniciID != value))
				{
					this.OnkullaniciIDChanging(value);
					this.SendPropertyChanging();
					this._kullaniciID = value;
					this.SendPropertyChanged("kullaniciID");
					this.OnkullaniciIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kullaniciAdi", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string kullaniciAdi
		{
			get
			{
				return this._kullaniciAdi;
			}
			set
			{
				if ((this._kullaniciAdi != value))
				{
					this.OnkullaniciAdiChanging(value);
					this.SendPropertyChanging();
					this._kullaniciAdi = value;
					this.SendPropertyChanged("kullaniciAdi");
					this.OnkullaniciAdiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sifre", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string sifre
		{
			get
			{
				return this._sifre;
			}
			set
			{
				if ((this._sifre != value))
				{
					this.OnsifreChanging(value);
					this.SendPropertyChanging();
					this._sifre = value;
					this.SendPropertyChanged("sifre");
					this.OnsifreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kullaniciEmail", CanBeNull=false)]
		public string kullaniciEmail
		{
			get
			{
				return this._kullaniciEmail;
			}
			set
			{
				if ((this._kullaniciEmail != value))
				{
					this.OnkullaniciEmailChanging(value);
					this.SendPropertyChanging();
					this._kullaniciEmail = value;
					this.SendPropertyChanged("kullaniciEmail");
					this.OnkullaniciEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_beniHatirla")]
		public bool beniHatirla
		{
			get
			{
				return this._beniHatirla;
			}
			set
			{
				if ((this._beniHatirla != value))
				{
					this.OnbeniHatirlaChanging(value);
					this.SendPropertyChanging();
					this._beniHatirla = value;
					this.SendPropertyChanged("beniHatirla");
					this.OnbeniHatirlaChanged();
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
