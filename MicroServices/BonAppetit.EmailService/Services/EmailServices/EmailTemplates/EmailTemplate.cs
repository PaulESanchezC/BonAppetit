namespace Services.EmailServices.EmailTemplates;

public static class EmailTemplate
{
    public const string RestaurantRegistration = @"
<head>
<style>
    @import url('https://fonts.googleapis.com/css2?family=Comfortaa:wght@300&display=swap');
    
 table,tbody,tr,td,span,a font-family: 'Comfortaa', cursive ;

</style>
</head>
<table width='100%' height='100%' style='padding:0px;margin:50px auto; min-width:400px;'>
    <tbody>
        <tr>
            <td width = '100%' align='center' style='margin:0px auto;'>
                <table width = '100%' align='center' style='margin:auto'>
                    <tbody>
                        <tr>
                            <td>
                                <table align = 'center' width='100%' style='margin: auto;
                                border-top: 2px solid #11a8ab; border-bottom: 2px solid #11a8ab;'>
                                    <tbody>
                                        <tr>
                                            <td align='left' style='margin: auto; font-size:18px;'>
                                                <a href ='' >'Add href' Bon Appetit Reservation Manager App </ a >
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' style='margin: auto; border-bottom: 2px solid #11a8ab;font-size: 24px'>
                                                Developed by: Paul Sanchez.
                                            </td>
                                        </tr>
                                        <tr><td style = 'margin: auto;' > &nbsp;</td></tr>
                                        <tr>
                                            <td align = 'center' style='padding: 10px 15px; margin: 15px; font-weight: bold; line-height: 36px;
                                            margin: auto; font-size: 36px;'>
                                                <span style = 'color: #11a8ab' > Welcome To Bon Appetit Reservation Manager </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                Restaurant: {0} <br/>
                                                Restaurant Address: {1} <br/>
                                                Restaurant Phone: {2} <br/>
                                                Restaurant Website: {3} <br/>
                                                Restaurant City: {4} <br/>
                                                Restaurant Cusine: {5} <br/>
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto; '> &nbsp; </td></tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                <span> Restaurant profile.</span> <br/>
                                                <span> This email confirms the creation of the restaurant account, There are many options to follow,
                                                 so please follow <a href=''>Add Guidelines</a>these guidelines</span> <br/>
                                            </td>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                <span> Thank you for using Bon Appetit Restaurant Reservation Manager.</span> <br/>
                                            </td>
                                        <tr>
                                            <td align = 'center' style='margin:auto; line-height: 18px;'>
                                                <a href = '{3}' target='_blank'
                                                   style='text-decoration: none; border-radius: 50px; padding: 12px 18px;
                                                      border: 1px solid #11a8ab; display: inline-block; font-size:20px;'>
                                                    {4}
                                                </a>
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto;'> &nbsp; </td></tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>";

    public const string ManagerRegistration = @"
<head>
<style>
    @import url('https://fonts.googleapis.com/css2?family=Comfortaa:wght@300&display=swap');
    
 table,tbody,tr,td,span,a font-family: 'Comfortaa', cursive ;

</style>
</head>
<table width='100%' height='100%' style='padding:0px;margin:50px auto; min-width:400px;'>
    <tbody>
        <tr>
            <td width = '100%' align='center' style='margin:0px auto;'>
                <table width = '100%' align='center' style='margin:auto'>
                    <tbody>
                        <tr>
                            <td>
                                <table align = 'center' width='100%' style='margin: auto;
                                border-top: 2px solid #11a8ab; border-bottom: 2px solid #11a8ab;'>
                                    <tbody>
                                        <tr>
                                            <td align='left' style='margin: auto; font-size:18px;'>
                                                <a href ='' >'Add href' Bon Appetit Reservation Manager App </ a >
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' style='margin: auto; border-bottom: 2px solid #11a8ab;font-size: 24px'>
                                                Developed by: Paul Sanchez.
                                            </td>
                                        </tr>
                                        <tr><td style = 'margin: auto;' > &nbsp;</td></tr>
                                        <tr>
                                            <td align = 'center' style='padding: 10px 15px; margin: 15px; font-weight: bold; line-height: 36px;
                                            margin: auto; font-size: 36px;'>
                                                <span style = 'color: #11a8ab' > Welcome To Bon Appetit Reservation Manager </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                Restaurant: {0} <br/>
                                                Restaurant Phone: {2} <br/>
                                                Restaurant Email: {3} <br/>                                                
                                            </td>                                            
                                            
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                Your Name: {4} {5} <br/>
                                                Your Phone: {6} <br/>
                                                Your Email: {7} <br/>
                                                <span>Here: put information about how to use the app as a manager:</span><br/>
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto; '> &nbsp; </td></tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33;     
                                                <span>For more information on how to use the app, please refer to these <a href=''>Guidelines add href</a></span><br/>
                                            </td>
                                        <tr>
                                            <td align = 'center' style='margin:auto; line-height: 18px;'>
                                                <a href = '{3}' target='_blank'                                                     
                                                   style='text-decoration: none; border-radius: 50px; padding: 12px 18px;
                                                      border: 1px solid #11a8ab; display: inline-block; font-size:20px;'>
                                                    {4}
                                                </a>
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto;'> &nbsp; </td></tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>";

    public const string WorkerRegistration = @"
<head>
<style>
    @import url('https://fonts.googleapis.com/css2?family=Comfortaa:wght@300&display=swap');
    
 table,tbody,tr,td,span,a font-family: 'Comfortaa', cursive ;

</style>
</head>
<table width='100%' height='100%' style='padding:0px;margin:50px auto; min-width:400px;'>
    <tbody>
        <tr>
            <td width = '100%' align='center' style='margin:0px auto;'>
                <table width = '100%' align='center' style='margin:auto'>
                    <tbody>
                        <tr>
                            <td>
                                <table align = 'center' width='100%' style='margin: auto;
                                border-top: 2px solid #11a8ab; border-bottom: 2px solid #11a8ab;'>
                                    <tbody>
                                        <tr>
                                            <td align='left' style='margin: auto; font-size:18px;'>
                                                <a href ='' >'Add href' Bon Appetit Reservation Manager App </ a >
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' style='margin: auto; border-bottom: 2px solid #11a8ab;font-size: 24px'>
                                                Developed by: Paul Sanchez.
                                            </td>
                                        </tr>
                                        <tr><td style = 'margin: auto;' > &nbsp;</td></tr>
                                        <tr>
                                            <td align = 'center' style='padding: 10px 15px; margin: 15px; font-weight: bold; line-height: 36px;
                                            margin: auto; font-size: 36px;'>
                                                <span style = 'color: #11a8ab' > Welcome To Bon Appetit Reservation Manager </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                Restaurant: {0} <br/>
                                                Restaurant Phone: {2} <br/>
                                                Restaurant Email: {3} <br/>                                                
                                            </td>                                            
                                            
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                Your Name: {4} {5} <br/>
                                                Your Phone: {6} <br/>
                                                Your Email: {7} <br/>
                                                <span>Here: put information about how to use the app as a manager:</span><br/>
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto; '> &nbsp; </td></tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33;     
                                                <span>For more information on how to use the app, please refer to these <a href=''>Guidelines add href</a></span><br/>
                                            </td>
                                        <tr>
                                            <td align = 'center' style='margin:auto; line-height: 18px;'>
                                                <a href = '{3}' target='_blank'                                                     
                                                   style='text-decoration: none; border-radius: 50px; padding: 12px 18px;
                                                      border: 1px solid #11a8ab; display: inline-block; font-size:20px;'>
                                                    {4}
                                                </a>
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto;'> &nbsp; </td></tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>";

    public const string ClientRegistration = @"
<head>
<style>
    @import url('https://fonts.googleapis.com/css2?family=Comfortaa:wght@300&display=swap');
    
 table,tbody,tr,td,span,a font-family: 'Comfortaa', cursive ;

</style>
</head>
<table width='100%' height='100%' style='padding:0px;margin:50px auto; min-width:400px;'>
    <tbody>
        <tr>
            <td width = '100%' align='center' style='margin:0px auto;'>
                <table width = '100%' align='center' style='margin:auto'>
                    <tbody>
                        <tr>
                            <td>
                                <table align = 'center' width='100%' style='margin: auto;
                                border-top: 2px solid #11a8ab; border-bottom: 2px solid #11a8ab;'>
                                    <tbody>
                                        <tr>
                                            <td align='left' style='margin: auto; font-size:18px;'>
                                                <a href ='' >'Add href' Bon Appetit Reservation Manager App </ a >
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' style='margin: auto; border-bottom: 2px solid #11a8ab;font-size: 24px'>
                                                Developed by: Paul Sanchez.
                                            </td>
                                        </tr>
                                        <tr><td style = 'margin: auto;' > &nbsp;</td></tr>
                                        <tr>
                                            <td align = 'center' style='padding: 10px 15px; margin: 15px; font-weight: bold; line-height: 36px;
                                            margin: auto; font-size: 36px;'>
                                                <span style = 'color: #11a8ab' > Welcome To Bon Appetit Reservation Manager </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                Restaurant: {0} <br/>
                                                Restaurant Phone: {2} <br/>
                                                Restaurant Email: {3} <br/>                                                
                                            </td>                                            
                                            
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                Your Name: {4} {5} <br/>
                                                Your Phone: {6} <br/>
                                                Your Email: {7} <br/>
                                                <span>Here: put information about how to use the app as a manager:</span><br/>
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto; '> &nbsp; </td></tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33;     
                                                <span>For more information on how to use the app, please refer to these <a href=''>Guidelines add href</a></span><br/>
                                            </td>
                                        <tr>
                                            <td align = 'center' style='margin:auto; line-height: 18px;'>
                                                <a href = '{3}' target='_blank'                                                     
                                                   style='text-decoration: none; border-radius: 50px; padding: 12px 18px;
                                                      border: 1px solid #11a8ab; display: inline-block; font-size:20px;'>
                                                    {4}
                                                </a>
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto;'> &nbsp; </td></tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>";

    public const string ReservationManager = @"
<head>
<style>
    @import url('https://fonts.googleapis.com/css2?family=Comfortaa:wght@300&display=swap');
    
 table,tbody,tr,td,span,a{0}font-family: 'Comfortaa', cursive ;{1}

</style>
</head>
<table width='100%' height='100%' style='padding:0px;margin:50px auto; min-width:400px;'>
    <tbody>
        <tr>
            <td width = '100%' align='center' style='margin:0px auto;'>
                <table width = '100%' align='center' style='margin:auto'>
                    <tbody>
                        <tr>
                            <td>
                                <table align = 'center' width='100%' style='margin: auto;
                                border-top: 2px solid #11a8ab; border-bottom: 2px solid #11a8ab;'>
                                    <tbody>
                                        <tr>
                                            <td align='left' style='margin: auto; font-size:18px;'>
                                                <a href = 'https://localhost:44304/Home' > AutoSeller </ a >
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' style='margin: auto; border-bottom: 2px solid #11a8ab;font-size: 24px'>
                                                Developed by: Paul Sanchez.
                                            </td>
                                        </tr>
                                        <tr><td style = 'margin: auto;' > &nbsp;</td></tr>
                                        <tr>
                                            <td align = 'center' style='padding: 10px 15px; margin: 15px; font-weight: bold; line-height: 36px;
                                            margin: auto; font-size: 36px;'>
                                                <span style = 'color: #11a8ab' > AutoSeller </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                {2}
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto; '> &nbsp; </td></tr>
                                        <tr>
                                            <td align = 'center' style='margin:auto; line-height: 18px;'>
                                                <a href = '{3}' target='_blank'                                                     
                                                   style='text-decoration: none; border-radius: 50px; padding: 12px 18px;
                                                      border: 1px solid #11a8ab; display: inline-block; font-size:20px;'>
                                                    {4}
                                                </a>
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto;'> &nbsp; </td></tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>";

    public const string ReservationClients = @"
<head>
<style>
    @import url('https://fonts.googleapis.com/css2?family=Comfortaa:wght@300&display=swap');
    
 table,tbody,tr,td,span,a{0}font-family: 'Comfortaa', cursive ;{1}

</style>
</head>
<table width='100%' height='100%' style='padding:0px;margin:50px auto; min-width:400px;'>
    <tbody>
        <tr>
            <td width = '100%' align='center' style='margin:0px auto;'>
                <table width = '100%' align='center' style='margin:auto'>
                    <tbody>
                        <tr>
                            <td>
                                <table align = 'center' width='100%' style='margin: auto;
                                border-top: 2px solid #11a8ab; border-bottom: 2px solid #11a8ab;'>
                                    <tbody>
                                        <tr>
                                            <td align='left' style='margin: auto; font-size:18px;'>
                                                <a href = 'https://localhost:44304/Home' > AutoSeller </ a >
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' style='margin: auto; border-bottom: 2px solid #11a8ab;font-size: 24px'>
                                                Developed by: Paul Sanchez.
                                            </td>
                                        </tr>
                                        <tr><td style = 'margin: auto;' > &nbsp;</td></tr>
                                        <tr>
                                            <td align = 'center' style='padding: 10px 15px; margin: 15px; font-weight: bold; line-height: 36px;
                                            margin: auto; font-size: 36px;'>
                                                <span style = 'color: #11a8ab' > AutoSeller </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                {2}
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto; '> &nbsp; </td></tr>
                                        <tr>
                                            <td align = 'center' style='margin:auto; line-height: 18px;'>
                                                <a href = '{3}' target='_blank'                                                     
                                                   style='text-decoration: none; border-radius: 50px; padding: 12px 18px;
                                                      border: 1px solid #11a8ab; display: inline-block; font-size:20px;'>
                                                    {4}
                                                </a>
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto;'> &nbsp; </td></tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>";
}