<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
<html>
<head>
    <meta charset="utf-8" />
    <title>Specimen Inventory</title>
</head>
<body>
    <h1>My Specimen Collection</h1>
  <p>I really like native edible shade tolerant plants.</p>
    <table style="width:100%;" border="1">
        <tr>
            <th>Latitude</th><th>Longitude</th><th>Description</th><th>Planted By</th>
        </tr>
      <xsl:for-each select="/plant/specimens/specimen">
        <tr>
            <td><xsl:value-of select="latitude"/></td>
            <td>
              <xsl:value-of select="longitude"/>
            </td>
            <td>
              <xsl:value-of select="description"/>
            </td>
            <td>
              <xsl:value-of select="planted_by"/>
            </td>
        </tr>
        </xsl:for-each>
    </table>
</body>
</html>
  </xsl:template>
</xsl:stylesheet>