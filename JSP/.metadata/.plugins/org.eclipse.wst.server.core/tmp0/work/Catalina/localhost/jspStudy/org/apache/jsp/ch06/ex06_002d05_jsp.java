/*
 * Generated by the Jasper component of Apache Tomcat
 * Version: Apache Tomcat/7.0.88
 * Generated at: 2018-07-10 04:12:14 UTC
 * Note: The last modified time of this file was set to
 *       the last modified time of the source file after
 *       generation to assist with modification tracking.
 */
package org.apache.jsp.ch06;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;

public final class ex06_002d05_jsp extends org.apache.jasper.runtime.HttpJspBase
    implements org.apache.jasper.runtime.JspSourceDependent {

  private static final javax.servlet.jsp.JspFactory _jspxFactory =
          javax.servlet.jsp.JspFactory.getDefaultFactory();

  private static java.util.Map<java.lang.String,java.lang.Long> _jspx_dependants;

  private volatile javax.el.ExpressionFactory _el_expressionfactory;
  private volatile org.apache.tomcat.InstanceManager _jsp_instancemanager;

  public java.util.Map<java.lang.String,java.lang.Long> getDependants() {
    return _jspx_dependants;
  }

  public javax.el.ExpressionFactory _jsp_getExpressionFactory() {
    if (_el_expressionfactory == null) {
      synchronized (this) {
        if (_el_expressionfactory == null) {
          _el_expressionfactory = _jspxFactory.getJspApplicationContext(getServletConfig().getServletContext()).getExpressionFactory();
        }
      }
    }
    return _el_expressionfactory;
  }

  public org.apache.tomcat.InstanceManager _jsp_getInstanceManager() {
    if (_jsp_instancemanager == null) {
      synchronized (this) {
        if (_jsp_instancemanager == null) {
          _jsp_instancemanager = org.apache.jasper.runtime.InstanceManagerFactory.getInstanceManager(getServletConfig());
        }
      }
    }
    return _jsp_instancemanager;
  }

  public void _jspInit() {
  }

  public void _jspDestroy() {
  }

  public void _jspService(final javax.servlet.http.HttpServletRequest request, final javax.servlet.http.HttpServletResponse response)
        throws java.io.IOException, javax.servlet.ServletException {

    final javax.servlet.jsp.PageContext pageContext;
    javax.servlet.http.HttpSession session = null;
    final javax.servlet.ServletContext application;
    final javax.servlet.ServletConfig config;
    javax.servlet.jsp.JspWriter out = null;
    final java.lang.Object page = this;
    javax.servlet.jsp.JspWriter _jspx_out = null;
    javax.servlet.jsp.PageContext _jspx_page_context = null;


    try {
      response.setContentType("text/html; charset=UTF-8");
      pageContext = _jspxFactory.getPageContext(this, request, response,
      			null, true, 8192, true);
      _jspx_page_context = pageContext;
      application = pageContext.getServletContext();
      config = pageContext.getServletConfig();
      session = pageContext.getSession();
      out = pageContext.getOut();
      _jspx_out = out;

      out.write("\r\n");
      out.write("<!DOCTYPE html>\r\n");
      out.write("<html>\r\n");
      out.write("<head>\r\n");
      out.write("<meta charset=\"UTF-8\">\r\n");
      out.write("<title>입력 폼[3]</title>\r\n");
      out.write("</head>\r\n");
      out.write("<body>\r\n");
      out.write("<center>\r\n");
      out.write("\t<h4>보고 싶은 영화제목 선택하기</h4>\r\n");
      out.write("\t\r\n");
      out.write("\t보고 싶은 영화를 선택해 주세요.<br>\r\n");
      out.write("\t(여러제목을 선택할 경우에는 Ctrl키를 사용하세요.)\r\n");
      out.write("\t\r\n");
      out.write("\t<form method=post action=ex06-06.jsp>\r\n");
      out.write("\t\t<select name=movie size=4 multiple>\r\n");
      out.write("\t\t\t<option value=\"설국열차\" selected>설국열차\r\n");
      out.write("\t\t\t<option value=\"레드:더 레전드\">레드:더 레전드\r\n");
      out.write("\t\t\t<option value=\"친구\">친구\r\n");
      out.write("\t\t\t<option value=\"감시자들\">감시자들\r\n");
      out.write("\t\t\t<option value=\"피아니스트\">피아니스트\r\n");
      out.write("\t\t\t<option value=\"대부\">대부\r\n");
      out.write("\t\t</select><p>\r\n");
      out.write("\t\t\r\n");
      out.write("\t\t<input type=submit value=\" 전 송 \">\r\n");
      out.write("\t\t<input type=reset value=\" 취 소 \">\r\n");
      out.write("\t</form>\r\n");
      out.write("</center>\r\n");
      out.write("</body>\r\n");
      out.write("</html>");
    } catch (java.lang.Throwable t) {
      if (!(t instanceof javax.servlet.jsp.SkipPageException)){
        out = _jspx_out;
        if (out != null && out.getBufferSize() != 0)
          try {
            if (response.isCommitted()) {
              out.flush();
            } else {
              out.clearBuffer();
            }
          } catch (java.io.IOException e) {}
        if (_jspx_page_context != null) _jspx_page_context.handlePageException(t);
        else throw new ServletException(t);
      }
    } finally {
      _jspxFactory.releasePageContext(_jspx_page_context);
    }
  }
}
