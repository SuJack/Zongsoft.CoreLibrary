/*
 * Authors:
 *   �ӷ�(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2008-2015 Zongsoft Corporation <http://www.zongsoft.com>
 *
 * This file is part of Zongsoft.CoreLibrary.
 *
 * Zongsoft.CoreLibrary is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * Zongsoft.CoreLibrary is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with Zongsoft.CoreLibrary; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
 */

using System;
using System.ComponentModel;
using System.Reflection;

namespace Zongsoft.Common
{
	/// <summary>
	/// ��ʾö�����������
	/// </summary>
	[Serializable]
	public class EnumEntry : IFormattable, IFormatProvider
	{
		#region ��Ա����
		private Type _type;
		private string _name;
		private object _value;
		private string _alias;
		private string _description;
		#endregion

		#region ���캯��
		public EnumEntry(Type type, string name, object value, string alias, string description)
		{
			_type = type;
			_name = name;
			_value = value;
			_alias = alias ?? string.Empty;
			_description = description ?? string.Empty;
		}
		#endregion

		#region ��������
		/// <summary>
		/// ��ȡö��������ơ�
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}
		}

		/// <summary>
		/// ��ȡö�ٵ����͡�
		/// </summary>
		public Type Type
		{
			get
			{
				return _type;
			}
		}

		/// <summary>
		/// ��ǰ������ö����ֵ����ֵ�п���Ϊö�����ֵҲ�����Ƕ�Ӧ�Ļ�Ԫ����ֵ��
		/// </summary>
		public object Value
		{
			get
			{
				return _value;
			}
		}

		/// <summary>
		/// ��ȡö����ı��������δ���彨�鴴��������Ϊö��������ơ�
		/// </summary>
		/// <remarks>ö����ı�����<seealso cref="Zongsoft.ComponentModel.AliasAttribute"/>�Զ�������ָ����</remarks>
		public string Alias
		{
			get
			{
				return _alias;
			}
		}

		/// <summary>
		/// ��ǰ����ö����������ı������δ���彨�鴴��������Ϊö��������ơ�
		/// </summary>
		/// <remarks>ö�����������<seealso cref="System.ComponentModel.DescriptionAttribute"/>�Զ�������ָ����</remarks>
		public string Description
		{
			get
			{
				return _description;
			}
		}
		#endregion

		#region ��д����
		public override string ToString()
		{
			string value;

			if(_value.GetType().IsPrimitive)
				value = _value.ToString();
			else
			{
				FieldInfo field = _type.GetField(_name);
				value = System.Convert.ChangeType(field.GetValue(null), Enum.GetUnderlyingType(_type)).ToString();
			}

			return string.Format("{0}.{1} = {2}", _type.FullName, _name, value);
		}
		#endregion

		#region ��ʽ����
		public string ToString(string format)
		{
			if(string.IsNullOrWhiteSpace(format))
				return _value.ToString();

			switch(format.Trim().ToLowerInvariant())
			{
				case "d":
				case "description":
					return _description;
				case "n":
				case "name":
					return _name;
				case "a":
				case "alias":
					return _alias;
				case "f":
				case "full":
				case "fullname":
					return this.ToString();
			}

			return _value.ToString();
		}

		string IFormattable.ToString(string format, IFormatProvider formatProvider)
		{
			return this.ToString(format);
		}

		object IFormatProvider.GetFormat(Type formatType)
		{
			if(formatType == typeof(ICustomFormatter))
				return this;

			return null;
		}
		#endregion
	}
}