<?xml version = "1.0" encoding = "UTF-8"?>
<xsl:stylesheet version = "1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>My Shortcuts </title>
      </head>
      <body>
        <h1>My Team's favorite Shortcuts</h1>
        <br/>
        <div>
          <table border="1" width="100%">
            <tr bgcolor="#9acd32">
              <th style="text-align:left">First Name</th>
              <th style="text-align:left">Last Name</th>
              <th style="text-align:left">BearCat ID</th>
              <th style="text-align:left">Shortcut</th>

            </tr>
            <xsl:for-each select="users/user">
              <tr>
                <td>
                  <xsl:value-of select="firstname"/>
                </td>
                <td>
                  <xsl:value-of select="lastname"/>
                </td>
                <td>
                  <xsl:value-of select="bearcatid"/>
                </td>
                <td>
                  <xsl:value-of select="favoriteshortcut"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>