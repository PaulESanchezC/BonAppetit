namespace Services.EmailServices.EmailTemplates;

public static class EmailTemplate
{
    public const string RestaurantRegistration = @"
<head>
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
                                                <span style = 'color: #11a8ab' > Welcome To {0} Staff </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                <span> Welcome {1} {2}, here is your contact information: </span></br>
                                                <span> Phone number:  {3},</span></br>
                                                <span> Email:  {4},</span></br>
                                                <span> and your manager's your contact information: </span></br>
                                                <span> Name: {5} {6},</span></br>
                                                <span> Phone number:  {7},</span></br>
                                                <span> Email:  {8},</span></br>
                                            </td>                                            
                                            
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                <span> Restauran's information:,</span></br>
                                                Restauran's Name: {0} <br/>
                                                Restauran's Phone: {9} <br/>
                                                Restauran's Email: {10} <br/>
                                                <span>Here: put information about how to use the app as a worker:</span><br/>
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
                                                <span style = 'color: #11a8ab' > Welcome To Bon Appetit </span>
                                            </td>
                                        </tr>
                                        <tr>                                                                                        
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                Your Name: {0} {1} <br/>
                                                Your Phone: {2} <br/>
                                                Your Email: {3} <br/>
                                                Your Coupon Code: {4} <br/>
                                                <span>Here: put information about how to use the app as a client:</span><br/>
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
                                                <a href = ''> Bon Appetit Restaurant Reservation Manager App Add Href</ a >
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
                                                <span style = 'color: #11a8ab' > Someone made a reservation </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                <span> Order Number: {0},</span> <br/>
                                                <span> Table: {1},</span> <br/>
                                                <span> Date of reservation: {2},</span> <br/>
                                                <span> Start time: {3},</span> <br/>
                                                <span> Reservation for: {4},</span> <br/>
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto; '> &nbsp; </td></tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                <span> Name of : {5} {6},</span> <br/>
                                                <span> Phone: {7},</span> <br/>
                                                <span> Email: {8},</span> <br/>
                                            </td>
                                        <tr>
                                            <td align = 'center' style='margin:auto; line-height: 18px;'>                                            
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
                                                <a href = '' > Bon Appetit  add href</ a >
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
                                                <span style = 'color: #11a8ab' > Bon Appetit Reservation </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                <span> Reservation information: </span> <br/>
                                                <span> Restaurant: {0} </span> <br/>
                                                <span> Reservation for: {1} </span> <br/>
                                                <span> Date of reservation: {2} </span> <br/>
                                                <span> Start time: {3} </span> <br/>
                                                <span> Order number: {4} </span> <br/>
                                            </td>
                                        </tr>
                                        <tr><td height = '20px' style='margin: auto; '> &nbsp; </td></tr>
                                                <td align='left' height='48px' style='padding: 6px 8px; margin: 10px; margin: auto; color: #292f33; 
                                                font-size: 24px;'>
                                                <span> Your Information </span> <br/>                                                
                                                <span> Name: {5} {6} </span> <br/>                                                
                                                <span> Phone: {7} </span> <br/>                                                
                                                <span> Email: {8} </span> <br/>                                                
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
}