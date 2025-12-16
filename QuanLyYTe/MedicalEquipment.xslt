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
        <title>Danh Sách Vật Tư Y Tế</title>
        <style>
          * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
          }
          body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #30cfd0 0%, #330867 100%);
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
            background: linear-gradient(135deg, #30cfd0 0%, #330867 100%);
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
            overflow-x: auto;
          }
          table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            font-size: 14px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
          }
          th {
            background: linear-gradient(135deg, #30cfd0 0%, #330867 100%);
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
            <h1>💊 DANH SÁCH VẬT TƯ Y TẾ</h1>
          </div>
          <div class="content">
            <table>
              <thead>
                <tr>
                  <th>STT</th>
                  <th>Mã vật tư</th>
                  <th>Tên vật tư</th>
                  <th>Ngày nhập</th>
                  <th>Loại vật tư</th>
                  <th>Số lượng</th>
                  <th>Giá</th>
                </tr>
              </thead>
              <tbody>
                <!-- Bỏ qua nút schema, chỉ lặp qua các dòng dữ liệu -->
                <xsl:for-each select="*[local-name() != 'schema']">
                  <xsl:variable name="maVatTu" select="*[contains(local-name(), 'Mã') and contains(local-name(), 'vật')] | *[local-name()='MaVatTuYTE']"/>
                  <xsl:variable name="tenVatTu" select="*[contains(local-name(), 'Tên') and contains(local-name(), 'vật')] | *[local-name()='TenVatTuYTE']"/>
                  <xsl:variable name="loaiVatTu" select="*[contains(local-name(), 'Loại')] | *[local-name()='TenLoaiVatTuYTE']"/>
                  
                  <xsl:if test="(string($maVatTu) != '' and contains($maVatTu, $Data)) or (string($tenVatTu) != '' and contains($tenVatTu, $Data)) or (string($loaiVatTu) != '' and contains($loaiVatTu, $Data))">
                    <tr>
                      <td>
                        <xsl:value-of select="position()"/>
                      </td>
                      <td>
                        <xsl:value-of select="$maVatTu"/>
                      </td>
                      <td>
                        <xsl:value-of select="$tenVatTu"/>
                      </td>
                      <td>
                        <xsl:value-of select="*[contains(local-name(), 'Ngày')] | *[local-name()='NgayNhap']"/>
                      </td>
                      <td>
                        <xsl:value-of select="$loaiVatTu"/>
                      </td>
                      <td>
                        <xsl:value-of select="*[contains(local-name(), 'Số')] | *[local-name()='SoLuong']"/>
                      </td>
                      <td>
                        <xsl:value-of select="*[contains(local-name(), 'Giá')] | *[local-name()='Gia']"/>
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
