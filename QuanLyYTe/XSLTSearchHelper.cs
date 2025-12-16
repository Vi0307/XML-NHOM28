using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace QuanLyYTe
{
    public static class XSLTSearchHelper
    {
        public static void TimKiemXSLT(string data, string tenFileXML, string tenfileXSLT)
        {
            try
            {
                // Tìm file XSLT trong thư mục ứng dụng hoặc thư mục hiện tại
                string xsltPath = tenfileXSLT + ".xslt";
                if (!System.IO.File.Exists(xsltPath))
                {
                    // Thử tìm trong thư mục ứng dụng
                    string appDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    xsltPath = System.IO.Path.Combine(appDir, tenfileXSLT + ".xslt");
                }
                
                if (!System.IO.File.Exists(xsltPath))
                {
                    throw new FileNotFoundException($"Không tìm thấy file XSLT: {tenfileXSLT}.xslt");
                }

                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(xsltPath);
                XsltArgumentList argList = new XsltArgumentList();
                argList.AddParam("Data", "", data);
                XmlWriter writer = XmlWriter.Create(tenFileXML + ".html");
                xslt.Transform(new XPathDocument(tenFileXML + ".xml"), argList, writer);
                writer.Close();
                System.Diagnostics.Process.Start(tenFileXML + ".html");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện tìm kiếm XSLT: " + ex.Message);
            }
        }

        public static void TimKiemXSLTFromDataTable(DataTable dt, string data, string tenFileXML, string tenfileXSLT, string tableName = null)
        {
            try
            {
                // Tạo DataSet với tên NewDataSet để phù hợp với XSLT
                DataSet ds = new DataSet("NewDataSet");
                DataTable dtCopy = dt.Copy();
                
                // Đặt tên bảng nếu được cung cấp
                if (!string.IsNullOrEmpty(tableName))
                {
                    dtCopy.TableName = tableName;
                }
                
                ds.Tables.Add(dtCopy);
                
                // Xuất DataSet ra file XML
                ds.WriteXml(tenFileXML + ".xml", XmlWriteMode.WriteSchema);
                
                // Thực hiện XSLT transformation
                TimKiemXSLT(data, tenFileXML, tenfileXSLT);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện tìm kiếm XSLT từ DataTable: " + ex.Message);
            }
        }

        public static void XuatXSLTFromDataTable(DataTable dt, string tenFileXML, string tenfileXSLT, string tableName = null)
        {
            try
            {
                // Xuất toàn bộ dữ liệu (không tìm kiếm, Data = "")
                TimKiemXSLTFromDataTable(dt, "", tenFileXML, tenfileXSLT, tableName);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xuất dữ liệu XSLT: " + ex.Message);
            }
        }
    }
}

