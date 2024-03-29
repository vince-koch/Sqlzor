﻿using System.Diagnostics;

namespace Sqlzor.DbSchema.Models
{
    /// <summary>
    /// This schema collection exposes information about the data types that are supported by the database that the .NET Framework managed provider is currently connected to.
    /// </summary>
    [DebuggerDisplay("DataType [{TypeName}]")]
    public class DataTypeModel
    {
        /// <summary>
        /// The provider-specific data type name.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// The provider-specific type value that should be used when specifying a parameter's type. For example, SqlDbType.Money or OracleType.Blob.
        /// </summary>
        public int? ProviderDbType { get; set; }

        /// <summary>
        /// The length of a non-numeric column or parameter refers to either the maximum or the length defined for this type by the provider.
        /// For character data, this is the maximum or defined length in units, defined by the data source.Oracle has the concept of specifying a length and then specifying the actual storage size for some character data types. This defines only the length in units for Oracle.
        /// For date-time data types, this is the length of the string representation(assuming the maximum allowed precision of the fractional seconds component).
        /// If the data type is numeric, this is the upper bound on the maximum precision of the data type.
        /// </summary>
        public long? ColumnSize { get; set; }

        /// <summary>
        /// Format string that represents how to add this column to a data definition statement, such as CREATE TABLE.Each element in the CreateParameter array should be represented by a "parameter marker" in the format string.
        /// For example, the SQL data type DECIMAL needs a precision and a scale.In this case, the format string would be "DECIMAL({0},{1})".
        /// </summary>
        public string CreateFormat { get; set; }

        /// <summary>
        /// The creation parameters that must be specified when creating a column of this data type. Each creation parameter is listed in the string, separated by a comma in the order they are to be supplied.
        /// For example, the SQL data type DECIMAL needs a precision and a scale.In this case, the creation parameters should contain the string "precision, scale".
        /// In a text command to create a DECIMAL column with a precision of 10 and a scale of 2, the value of the CreateFormat column might be DECIMAL({ 0},{1})" and the complete type specification would be DECIMAL(10,2).
        /// </summary>
        public string CreateParameters { get; set; }

        /// <summary>
        /// The name of the.NET Framework type of the data type.
        /// </summary>
        public string DataTypeName { get; set; }

        /// <summary>
        /// true—Values of this data type may be auto-incrementing.
        /// false—Values of this data type may not be auto-incrementing.
        /// Note that this merely indicates whether a column of this data type may be auto-incrementing, not that all columns of this type are auto-incrementing.
        /// </summary>
        public bool? IsAutoincrementable { get; set; }

        /// <summary>
        /// true—The data type is the best match between all data types in the data store and the.NET Framework data type indicated by the value in the DataType column.
        /// false—The data type is not the best match.
        /// For each set of rows in which the value of the DataType column is the same, the IsBestMatch column is set to true in only one row.
        /// </summary>        
        public bool? IsBestMatch { get; set; }

        /// <summary>
        /// true—The data type is a character type and is case-sensitive.
        /// false—The data type is not a character type or is not case-sensitive.
        /// </summary>
        public bool? IsCaseSensitive { get; set; }

        /// <summary>
        /// true—Columns of this data type created by the data definition language (DDL) will be of fixed length.
        /// false—Columns of this data type created by the DDL will be of variable length.
        /// DBNull.Value—It is not known whether the provider will map this field with a fixed-length or variable - length column.
        /// </summary>
        public bool? IsFixedLength { get; set; }

        /// <summary>
        /// true—The data type has a fixed precision and scale.
        /// false—The data type does not have a fixed precision and scale.
        /// </summary>
        public bool? IsFixedPrecisionScale { get; set; }

        /// <summary>
        /// true—The data type contains very long data; the definition of very long data is provider-specific.
        /// false—The data type does not contain very long data.
        /// </summary>
        public bool? IsLong { get; set; }

        /// <summary>
        /// true—The data type is nullable.
        /// false—The data type is not nullable.
        /// DBNull.Value—It is not known whether the data type is nullable.
        /// </summary>
        public bool? IsNullable { get; set; }

        /// <summary>
        /// true—The data type can be used in a WHERE clause with any operator except the LIKE predicate.
        /// false—The data type cannot be used in a WHERE clause with any operator except the LIKE predicate.
        /// </summary>
        public bool? IsSearchable { get; set; }

        /// <summary>
        /// true—The data type can be used with the LIKE predicate
        /// false—The data type cannot be used with the LIKE predicate.
        /// </summary>
        public bool? IsSearchableWithLike { get; set; }

        /// <summary>
        /// true—The data type is unsigned.
        /// false—The data type is signed.
        /// DBNull.Value—Not applicable to data type.*
        /// </summary>
        public bool? IsUnsigned { get; set; }

        /// <summary>
        /// If the type indicator is a numeric type, this is the maximum number of digits allowed to the right of the decimal point. Otherwise, this is DBNull.Value.
        /// </summary>
        public short? MaximumScale { get; set; }

        /// <summary>
        /// If the type indicator is a numeric type, this is the minimum number of digits allowed to the right of the decimal point. Otherwise, this is DBNull.Value.
        /// </summary>
        public short? MinimumScale { get; set; }

        /// <summary>
        /// true – the data type is updated by the database every time the row is changed and the value of the column is different from all previous values
        /// false – the data type is note updated by the database every time the row is changed
        /// DBNull.Value – the database does not support this type of data type
        /// </summary>
        public bool? IsConcurrencyType { get; set; }

        /// <summary>
        /// true – the data type can be expressed as a literal
        /// false – the data type can not be expressed as a literal
        /// </summary>
        public bool? IsLiteralSupported { get; set; }

        /// <summary>
        /// The prefix applied to a given literal.
        /// </summary>
        public string LiteralPrefix { get; set; }

        /// <summary>
        /// The suffix applied to a given literal.
        /// </summary>
        public string LiteralSuffix { get; set; }

        /// <summary>
        /// NativeDataType is an OLE DB specific column for exposing the OLE DB type of the data type.
        /// </summary>
        public string NativeDataType { get; set; }
    }
}
