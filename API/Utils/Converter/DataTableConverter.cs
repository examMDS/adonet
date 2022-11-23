﻿using System.Data;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace API.Utils.Converter
{
    public class DataTableConverter : JsonConverter<DataTable>
    {
        public override DataTable Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, DataTable value,
            JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (DataRow row in value.Rows)
            {
                writer.WriteStartObject();
                foreach (DataColumn column in row.Table.Columns)
                {
                    object columnValue = row[column];
                    if (columnValue == null | columnValue is DBNull) columnValue = "null";

                    //if (options.IgnoreNullValues) { // Do null checks on the values here and skip writing. }

                    writer.WritePropertyName(column.ColumnName);
                    JsonSerializer.Serialize(writer, columnValue, options);
                }
                writer.WriteEndObject();
            }

            writer.WriteEndArray();
        }
    }
}
