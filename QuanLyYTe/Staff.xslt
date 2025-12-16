<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

  <xsl:param name="Data"></xsl:param>
  <xsl:template match="/NewDataSet">
    <html>
      <head>
        <meta charset="utf-8"/>
        <title>Danh Sách Nhân Viên</title>
        <style>
          * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
          }
          body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            padding: 20px;
            min-height: 100vh;
          }
          .container {
            max-width: 1400px;
            margin: 0 auto;
            background: white;
            border-radius: 15px;
            box-shadow: 0 10px 40px rgba(0,0,0,0.2);
            overflow: hidden;
          }
          .header {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 30px;
            text-align: center;
          }
          .header h1 {
            font-size: 32px;
            font-weight: 600;
            text-shadow: 2px 2px 4px rgba(0,0,0,0.3);
          }
          .content {
            padding: 30px;
          }
          table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            font-size: 14px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
          }
          th {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 15px 12px;
            text-align: left;
            font-weight: 600;
            text-transform: uppercase;
            font-size: 12px;
            letter-spacing: 0.5px;
            border: none;
          }
          th:first-child {
            border-top-left-radius: 8px;
          }
          th:last-child {
            border-top-right-radius: 8px;
          }
          td {
            padding: 12px;
            border-bottom: 1px solid #e0e0e0;
            color: #333;
          }
          tr {
            transition: all 0.3s ease;
          }
          tr:hover {
            background-color: #f5f7fa;
            transform: scale(1.01);
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
          }
          tr:nth-child(even) {
            background-color: #f9f9f9;
          }
          tr:nth-child(even):hover {
            background-color: #f0f2f5;
          }
          .no-data {
            text-align: center;
            padding: 40px;
            color: #999;
            font-size: 16px;
          }
        </style>
      </head>
      <body>
        <div class="container">
          <div class="header">
            <h1>📋 DANH SÁCH NHÂN VIÊN</h1>
          </div>
          <div class="content">
            <table>
              <thead>
                <tr>
                  <th>STT</th>
                  <th>Mã nhân viên</th>
                  <th>Tên nhân viên</th>
                  <th>Ngày sinh</th>
                  <th>Địa chỉ</th>
                  <th>Mã loại chức vụ</th>
                  <th>Tài khoản</th>
                  <th>Mã ca làm việc</th>
                </tr>
              </thead>
              <tbody>
                <xsl:for-each select="Staff">
                  <xsl:if test="MaNhanVien[contains(., $Data)] or TenNhanVien[contains(., $Data)] or DiaChi[contains(., $Data)] or TaiKhoan[contains(., $Data)]">
                    <tr>
                      <td>
                        <xsl:value-of select="position()"/>
                      </td>
                      <td>
                        <xsl:value-of select="MaNhanVien"/>
                      </td>
                      <td>
                        <xsl:value-of select="TenNhanVien"/>
                      </td>
                      <td>
                        <xsl:value-of select="NgaySinh"/>
                      </td>
                      <td>
                        <xsl:value-of select="DiaChi"/>
                      </td>
                      <td>
                        <xsl:value-of select="MaLoaiChucVu"/>
                      </td>
                      <td>
                        <xsl:value-of select="TaiKhoan"/>
                      </td>
                      <td>
                        <xsl:value-of select="MaCaLamViec"/>
                      </td>
                    </tr>
                  </xsl:if>
                </xsl:for-each>
              </tbody>
            </table>
          </div>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>

