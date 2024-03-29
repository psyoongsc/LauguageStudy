import java.sql.*;

public class ex1_2 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
        String url = "jdbc:mysql://127.0.0.1/test?useSSL=false&user=root&password=1122";
        Connection conn = null;
        Statement stmt = null;
        ResultSet rs = null;
        
        try {
            Class.forName("com.mysql.jdbc.Driver");
            System.out.println("드라이버 로드 성공!");
            
            conn = DriverManager.getConnection(url);
            System.out.println("데이터베이스 접속 성공!");
            
            stmt = conn.createStatement();
            String selectSql = "SELECT * FROM test;";
            rs = stmt.executeQuery(selectSql);
            
            while(rs.next())
            {
                System.out.println
                (
                    rs.getString(1) + "\t" +
                    rs.getString(2)
                );
            }
            
            ///////////////////////////////////////
            //구분선
            System.out.println("==============================================");
 
            //INSERT문 전송
            String insertSql = "INSERT INTO `test` VALUES ('3', 'qwer');";
            stmt.executeUpdate(insertSql);
            
            //test 테이블 조회
            rs = stmt.executeQuery(selectSql);
        
            while(rs.next())
            {
                System.out.println
                (
                    rs.getString(1) + "\t" +
                    rs.getString(2)
                );
            }
            //////////////////////////////////////
            
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        } catch (SQLException se) {
            se.printStackTrace();
        } finally {
            if(conn!=null) try {conn.close();} catch (SQLException e) {}
        }
	}
}
