﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EkbDataAccess
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="EKCabinetsDb")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAdmin(Admin instance);
    partial void UpdateAdmin(Admin instance);
    partial void DeleteAdmin(Admin instance);
    partial void InsertBrand(Brand instance);
    partial void UpdateBrand(Brand instance);
    partial void DeleteBrand(Brand instance);
    partial void InsertCabinet(Cabinet instance);
    partial void UpdateCabinet(Cabinet instance);
    partial void DeleteCabinet(Cabinet instance);
    partial void InsertLine(Line instance);
    partial void UpdateLine(Line instance);
    partial void DeleteLine(Line instance);
    partial void InsertPortfolio(Portfolio instance);
    partial void UpdatePortfolio(Portfolio instance);
    partial void DeletePortfolio(Portfolio instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::EkbDataAccess.Properties.Settings.Default.EKCabinetsDbConnectionString, mappingSource)
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
		
		public System.Data.Linq.Table<Admin> Admins
		{
			get
			{
				return this.GetTable<Admin>();
			}
		}
		
		public System.Data.Linq.Table<Brand> Brands
		{
			get
			{
				return this.GetTable<Brand>();
			}
		}
		
		public System.Data.Linq.Table<Cabinet> Cabinets
		{
			get
			{
				return this.GetTable<Cabinet>();
			}
		}
		
		public System.Data.Linq.Table<Line> Lines
		{
			get
			{
				return this.GetTable<Line>();
			}
		}
		
		public System.Data.Linq.Table<Portfolio> Portfolios
		{
			get
			{
				return this.GetTable<Portfolio>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetCabinetsAndLogoByLineID")]
		public ISingleResult<GetCabinetsAndLogoByLineIDResult> GetCabinetsAndLogoByLineID([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> lineId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), lineId);
			return ((ISingleResult<GetCabinetsAndLogoByLineIDResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Admins")]
	public partial class Admin : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Username;
		
		private string _Salt;
		
		private string _PasswordHash;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnSaltChanging(string value);
    partial void OnSaltChanged();
    partial void OnPasswordHashChanging(string value);
    partial void OnPasswordHashChanged();
    #endregion
		
		public Admin()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Salt", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Salt
		{
			get
			{
				return this._Salt;
			}
			set
			{
				if ((this._Salt != value))
				{
					this.OnSaltChanging(value);
					this.SendPropertyChanging();
					this._Salt = value;
					this.SendPropertyChanged("Salt");
					this.OnSaltChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Brand")]
	public partial class Brand : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private string _LogoFile;
		
		private EntitySet<Line> _Lines;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnLogoFileChanging(string value);
    partial void OnLogoFileChanged();
    #endregion
		
		public Brand()
		{
			this._Lines = new EntitySet<Line>(new Action<Line>(this.attach_Lines), new Action<Line>(this.detach_Lines));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(1000) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogoFile", DbType="VarChar(MAX)")]
		public string LogoFile
		{
			get
			{
				return this._LogoFile;
			}
			set
			{
				if ((this._LogoFile != value))
				{
					this.OnLogoFileChanging(value);
					this.SendPropertyChanging();
					this._LogoFile = value;
					this.SendPropertyChanged("LogoFile");
					this.OnLogoFileChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Brand_Line", Storage="_Lines", ThisKey="Id", OtherKey="BrandId")]
		public EntitySet<Line> Lines
		{
			get
			{
				return this._Lines;
			}
			set
			{
				this._Lines.Assign(value);
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
		
		private void attach_Lines(Line entity)
		{
			this.SendPropertyChanging();
			entity.Brand = this;
		}
		
		private void detach_Lines(Line entity)
		{
			this.SendPropertyChanging();
			entity.Brand = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Cabinet")]
	public partial class Cabinet : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _LineId;
		
		private string _Name;
		
		private string _DoorImage;
		
		private string _FullImage;
		
		private EntityRef<Line> _Line;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnLineIdChanging(int value);
    partial void OnLineIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDoorImageChanging(string value);
    partial void OnDoorImageChanged();
    partial void OnFullImageChanging(string value);
    partial void OnFullImageChanged();
    #endregion
		
		public Cabinet()
		{
			this._Line = default(EntityRef<Line>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LineId", DbType="Int NOT NULL")]
		public int LineId
		{
			get
			{
				return this._LineId;
			}
			set
			{
				if ((this._LineId != value))
				{
					if (this._Line.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLineIdChanging(value);
					this.SendPropertyChanging();
					this._LineId = value;
					this.SendPropertyChanged("LineId");
					this.OnLineIdChanged();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DoorImage", DbType="VarChar(1000)")]
		public string DoorImage
		{
			get
			{
				return this._DoorImage;
			}
			set
			{
				if ((this._DoorImage != value))
				{
					this.OnDoorImageChanging(value);
					this.SendPropertyChanging();
					this._DoorImage = value;
					this.SendPropertyChanged("DoorImage");
					this.OnDoorImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullImage", DbType="VarChar(MAX)")]
		public string FullImage
		{
			get
			{
				return this._FullImage;
			}
			set
			{
				if ((this._FullImage != value))
				{
					this.OnFullImageChanging(value);
					this.SendPropertyChanging();
					this._FullImage = value;
					this.SendPropertyChanged("FullImage");
					this.OnFullImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Line_Cabinet", Storage="_Line", ThisKey="LineId", OtherKey="Id", IsForeignKey=true)]
		public Line Line
		{
			get
			{
				return this._Line.Entity;
			}
			set
			{
				Line previousValue = this._Line.Entity;
				if (((previousValue != value) 
							|| (this._Line.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Line.Entity = null;
						previousValue.Cabinets.Remove(this);
					}
					this._Line.Entity = value;
					if ((value != null))
					{
						value.Cabinets.Add(this);
						this._LineId = value.Id;
					}
					else
					{
						this._LineId = default(int);
					}
					this.SendPropertyChanged("Line");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Line")]
	public partial class Line : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private string _FullImage;
		
		private int _BrandId;
		
		private string _Description;
		
		private EntitySet<Cabinet> _Cabinets;
		
		private EntitySet<Portfolio> _Portfolios;
		
		private EntityRef<Brand> _Brand;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnFullImageChanging(string value);
    partial void OnFullImageChanged();
    partial void OnBrandIdChanging(int value);
    partial void OnBrandIdChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public Line()
		{
			this._Cabinets = new EntitySet<Cabinet>(new Action<Cabinet>(this.attach_Cabinets), new Action<Cabinet>(this.detach_Cabinets));
			this._Portfolios = new EntitySet<Portfolio>(new Action<Portfolio>(this.attach_Portfolios), new Action<Portfolio>(this.detach_Portfolios));
			this._Brand = default(EntityRef<Brand>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullImage", DbType="VarChar(1000)")]
		public string FullImage
		{
			get
			{
				return this._FullImage;
			}
			set
			{
				if ((this._FullImage != value))
				{
					this.OnFullImageChanging(value);
					this.SendPropertyChanging();
					this._FullImage = value;
					this.SendPropertyChanged("FullImage");
					this.OnFullImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrandId", DbType="Int NOT NULL")]
		public int BrandId
		{
			get
			{
				return this._BrandId;
			}
			set
			{
				if ((this._BrandId != value))
				{
					if (this._Brand.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBrandIdChanging(value);
					this.SendPropertyChanging();
					this._BrandId = value;
					this.SendPropertyChanged("BrandId");
					this.OnBrandIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(2000)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Line_Cabinet", Storage="_Cabinets", ThisKey="Id", OtherKey="LineId")]
		public EntitySet<Cabinet> Cabinets
		{
			get
			{
				return this._Cabinets;
			}
			set
			{
				this._Cabinets.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Line_Portfolio", Storage="_Portfolios", ThisKey="Id", OtherKey="LineId")]
		public EntitySet<Portfolio> Portfolios
		{
			get
			{
				return this._Portfolios;
			}
			set
			{
				this._Portfolios.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Brand_Line", Storage="_Brand", ThisKey="BrandId", OtherKey="Id", IsForeignKey=true)]
		public Brand Brand
		{
			get
			{
				return this._Brand.Entity;
			}
			set
			{
				Brand previousValue = this._Brand.Entity;
				if (((previousValue != value) 
							|| (this._Brand.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Brand.Entity = null;
						previousValue.Lines.Remove(this);
					}
					this._Brand.Entity = value;
					if ((value != null))
					{
						value.Lines.Add(this);
						this._BrandId = value.Id;
					}
					else
					{
						this._BrandId = default(int);
					}
					this.SendPropertyChanged("Brand");
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
		
		private void attach_Cabinets(Cabinet entity)
		{
			this.SendPropertyChanging();
			entity.Line = this;
		}
		
		private void detach_Cabinets(Cabinet entity)
		{
			this.SendPropertyChanging();
			entity.Line = null;
		}
		
		private void attach_Portfolios(Portfolio entity)
		{
			this.SendPropertyChanging();
			entity.Line = this;
		}
		
		private void detach_Portfolios(Portfolio entity)
		{
			this.SendPropertyChanging();
			entity.Line = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Portfolio")]
	public partial class Portfolio : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _LineId;
		
		private string _Image;
		
		private EntityRef<Line> _Line;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnLineIdChanging(int value);
    partial void OnLineIdChanged();
    partial void OnImageChanging(string value);
    partial void OnImageChanged();
    #endregion
		
		public Portfolio()
		{
			this._Line = default(EntityRef<Line>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LineId", DbType="Int NOT NULL")]
		public int LineId
		{
			get
			{
				return this._LineId;
			}
			set
			{
				if ((this._LineId != value))
				{
					if (this._Line.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLineIdChanging(value);
					this.SendPropertyChanging();
					this._LineId = value;
					this.SendPropertyChanged("LineId");
					this.OnLineIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this.OnImageChanging(value);
					this.SendPropertyChanging();
					this._Image = value;
					this.SendPropertyChanged("Image");
					this.OnImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Line_Portfolio", Storage="_Line", ThisKey="LineId", OtherKey="Id", IsForeignKey=true)]
		public Line Line
		{
			get
			{
				return this._Line.Entity;
			}
			set
			{
				Line previousValue = this._Line.Entity;
				if (((previousValue != value) 
							|| (this._Line.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Line.Entity = null;
						previousValue.Portfolios.Remove(this);
					}
					this._Line.Entity = value;
					if ((value != null))
					{
						value.Portfolios.Add(this);
						this._LineId = value.Id;
					}
					else
					{
						this._LineId = default(int);
					}
					this.SendPropertyChanged("Line");
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
	
	public partial class GetCabinetsAndLogoByLineIDResult
	{
		
		private int _Id;
		
		private int _LineId;
		
		private string _Name;
		
		private string _DoorImage;
		
		private string _FullImage;
		
		private string _LogoFile;
		
		private string _LineName;
		
		private string _LineDescription;
		
		public GetCabinetsAndLogoByLineIDResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL")]
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
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LineId", DbType="Int NOT NULL")]
		public int LineId
		{
			get
			{
				return this._LineId;
			}
			set
			{
				if ((this._LineId != value))
				{
					this._LineId = value;
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
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DoorImage", DbType="VarChar(1000)")]
		public string DoorImage
		{
			get
			{
				return this._DoorImage;
			}
			set
			{
				if ((this._DoorImage != value))
				{
					this._DoorImage = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullImage", DbType="VarChar(MAX)")]
		public string FullImage
		{
			get
			{
				return this._FullImage;
			}
			set
			{
				if ((this._FullImage != value))
				{
					this._FullImage = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogoFile", DbType="VarChar(MAX)")]
		public string LogoFile
		{
			get
			{
				return this._LogoFile;
			}
			set
			{
				if ((this._LogoFile != value))
				{
					this._LogoFile = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LineName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string LineName
		{
			get
			{
				return this._LineName;
			}
			set
			{
				if ((this._LineName != value))
				{
					this._LineName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LineDescription", DbType="VarChar(2000)")]
		public string LineDescription
		{
			get
			{
				return this._LineDescription;
			}
			set
			{
				if ((this._LineDescription != value))
				{
					this._LineDescription = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
