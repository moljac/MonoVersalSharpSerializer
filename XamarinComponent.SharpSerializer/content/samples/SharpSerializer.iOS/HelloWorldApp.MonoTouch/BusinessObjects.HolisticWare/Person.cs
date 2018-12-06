using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldApp.BusinessObjects
{
	public partial class Person
	{
		//-------------------------------------------------------------------------
		# region Property string NameLast w Event post (NameLastChanged)
		/// <summary>
		/// NameLast
		/// </summary>
		public
		  string
		  NameLast
		{
			get
			{
				return name_last;
			} // NameLast.get
			set
			{
				//if (name_last != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(name_last) // MultiThread safe				
					{
						name_last = value;
						if (null != NameLastChanged)
						{
							NameLastChanged(this, new EventArgs());
						}
					}
				}
			} // NameLast.set
		} // NameLast

		/// <summary>
		/// private member field for holding NameLast data
		/// </summary>
		private
			string
			name_last
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// NameLastChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			NameLastChanged
			;
		# endregion Property string NameLast w Event post (NameLastChanged)
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		# region Property string NameFirst w Event post (NameFirstChanged)
		/// <summary>
		/// NameFirst
		/// </summary>
		public
		  string
		  NameFirst
		{
			get
			{
				return name_first;
			} // NameFirst.get
			set
			{
				//if (name_first != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(name_first) // MultiThread safe				
					{
						name_first = value;
						if (null != NameFirstChanged)
						{
							NameFirstChanged(this, new EventArgs());
						}
					}
				}
			} // NameFirst.set
		} // NameFirst

		/// <summary>
		/// private member field for holding NameFirst data
		/// </summary>
		private
			string
			name_first
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// NameFirstChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			NameFirstChanged
			;
		# endregion Property string NameFirst w Event post (NameFirstChanged)
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		# region Property DateTime DateOfBirth w Event post (DateOfBirthChanged)
		/// <summary>
		/// DateOfBirth
		/// </summary>
		public
		  DateTime
		  DateOfBirth
		{
			get
			{
				return date_of_birth;
			} // DateOfBirth.get
			set
			{
				//if (date_of_birth != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(date_of_birth) // MultiThread safe				
					{
						date_of_birth = value;
						if (null != DateOfBirthChanged)
						{
							DateOfBirthChanged(this, new EventArgs());
						}
					}
				}
			} // DateOfBirth.set
		} // DateOfBirth

		/// <summary>
		/// private member field for holding DateOfBirth data
		/// </summary>
		private
			DateTime
			date_of_birth
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// DateOfBirthChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			DateOfBirthChanged
			;
		# endregion Property DateTime DateOfBirth w Event post (DateOfBirthChanged)
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		# region Property double Age w Event post (AgeChanged)
		/// <summary>
		/// Age
		/// </summary>
		public
		  double
		  Age
		{
			get
			{
				return age;
			} // Age.get
			set
			{
				//if (age != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(age) // MultiThread safe				
					{
						age = value;
						if (null != AgeChanged)
						{
							AgeChanged(this, new EventArgs());
						}
					}
				}
			} // Age.set
		} // Age

		/// <summary>
		/// private member field for holding Age data
		/// </summary>
		private
			double
			age
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// AgeChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			AgeChanged
			;
		# endregion Property double Age w Event post (AgeChanged)
		//-------------------------------------------------------------------------
	}
}
