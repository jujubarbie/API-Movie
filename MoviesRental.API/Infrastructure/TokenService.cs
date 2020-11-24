using Microsoft.IdentityModel.Tokens;
using MoviesRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.API.Infrastructure
{
    public class TokenService
    {
        const string passPhrase = "vG5=kLfW!Ljzs^n*au_u@dPw5B$2N6$nkUe+KsvD@E9SnhXskA5qkK^&3br8jnF%c4adT-tAMfjRFkwYq9J6fq*NS&at-DtCtb8cdV@zJ3*pSAu9by6cQGR%-2Z2ps8NNAf#X$+S*VFhXuS*yH&Q9Y6Fqh_mS=S4m@bWdDpYG!&vVh8J2efa-ea*58ZPHtDc^bM48AcRXQ622aG-s5a2$nm_Zc@Cr&ezQ?YpTvZUMcv$&L6N9MnAfCw=u9@AF-te=pxGwUW2cwXNj7G=AJa8pfSs_+kNct^yZhTQ^d$rh8PPyf-HhPFyt_g!+-22bHgMYPW=&RFUjKD+5Utaz&E-aC_m-VFxDL7H+QsLB&6r?u_*8jNe+B7J^b&$$6c5Dhjv6z2dveG=!&&R=Z$5*N7DXG*+Dx&!EF%+E?2Wq7@Hy!ssXjWZEkvwZnvX!T*3ygBaRFG%sQpQxXV*!@r&nRz$2rL*pmJ4gYxS=7SCVBtQf6Lrhd@c+HKg$4qNabVMN+y3rFD=pbMPV-V#&tGNr3aZvR&b!nsS#g&dFxp_zqK2!rur$#9nzf9E!4@GcW^jrU#Rpn5wK?7!UH^m$*g*ZhXs?-5AayLd#gG9=acx?+pEEED5e3FXuUWZeh%b6Nst=dAetZ%Y9P%ks-aLMPgf3TZbbg-AzxgWfuh-bSCd#*U9RdQjB$bJ8AFpxU7_Us@7=GkcPc_bkb@&DxMQfYN99dpD7h-q=MxpjQUu#WMLfs4mkcJc!HG_Tuyj244+$DNVgzQ8Ep4tRAxnvBXqY$XLg*7x8Xw8yYsRV#mK3tx7*uhAdgwj58MeabLcfFj%5sbbAVvwfrXUzRQ_UEv?pg4M+7*$_Lpt!Q2HHvx%6Cb85W+!m5VW%cDfMj=4m5b6-BVmXF7QHexMT=^X%RN46X$wBNT!G@g7aSv@9s#Ks^YJN@?^sjaEp!ghFMTHt#ggRucd*4dQr?$eYK&h9jfaxY6kZ=DkdQAhE4rMq7GnR$b-ms66c@uhj2X6_jNd$BdX8-WBU4FnmYWJt_!%KBYb-r%KhnWmwBQC@8Ugv_CpMY9_gu6=Wau3gC9LH3V2rjCWj*RfVh&JED6dn+qAXQk4q8Vyp=MRuvEzWRd_P2_C=_tQGLyWw_wgXaJpXxptcRn$F+qQqHAc8+nC*WP2pyCSgJ@+%^XUXcG?UG-v5B8NWcYyTxHr4zC%nNb@TkfHR5QjZ8vs!N-h_=R8-eCEmTku=N_yD%7w4UCV_nQKX#a6ga3Ab#H#yGr76#$zJ=bmbBRQdjhan#L&Y6PGhUqYaemwA#RUBq^c%qRs7y=3SnpMep*WMes+vVPnm=r7*LWZUGP&et+kGN3v7&MD#y=*hSzXN&rvrQ7x%J&5yvz+TTK+UptVgh^9_LLC26b@hz4V%kf6_%v$GwY62kuNs_JWdWQsz@CFEka^VMV47PAvxRJFk%k?-Hg+jfY+@yP#Ue+e^3LyhFbGAv2A6r6tgC8n32gCGy4Apus$4Hjhf_vrzPjTq7wE=e$^2F&w4R=nZZnBd*!GkYhX3sdX9b%Bc&5q7a7XCfg_su=9J+F^4$8vHyEae*7GWgtZ39+cUTPaNw=Y#JEXJyg5M$cRXGvfH@s$ZF*$uPg7dZ$?m2qSY=c$nG^-wu@TcwgQy=d*bN^n-%mUvVYjSQc2snZR9PqECKc7tAHV5H%gTfmD6tuQYBavN6XVkySc%eBgWzDE7ZVpgtxbJp=98ZX8NUWAA$bKAH^$BsWxxr%9RFHVq2gXZf^-XWfL**PqpeMDXA#Pe%Ymf*jZkh287#pPQKWb7Twps@H!rGdkcCA5X26&JyrzBHdZzXSnQVP3Y@EXYLF+YHkPwte_kmfJLc3xX!!YjYHq@Q*x-64&5ZF9CbJgTBu9R8RnLUmg*sYNh3$#R?%v?t2V7tjtVKv^dSsQTcLX7RZVk$^CvJqhwdeTtBE8qt278qbkNNBEtkV4_tPeErq8@kK3-ytBC&UEv5M+266CA+HCnnA*QbNu3v2#drs7fByg@Z7-ZtNyq^jV4?Crf3MBmn3fz-L$$DgJm8@6b?b5";

        private JwtSecurityTokenHandler _handler;
        private JwtHeader _header;

        public JwtSecurityTokenHandler Handler {
            get {
                return _handler ??= new JwtSecurityTokenHandler();
            }
                 
        }
        public JwtHeader Header {
            get {


                if (_header is null)
                {
                    byte[] key = Encoding.UTF8.GetBytes(passPhrase); 
                    SymmetricSecurityKey ssKey = new SymmetricSecurityKey(key);
                    SigningCredentials sc = new SigningCredentials(
                            ssKey,
                            SecurityAlgorithms.HmacSha512
                        );
                    _header = new JwtHeader(sc);
                    
                }
                return _header;

                ///* Simplification */
                //return _header ??= new JwtHeader(
                //    new SigningCredentials(
                //        new SymmetricSecurityKey(Encoding.UTF8.GetBytes( passPhrase )),
                //        SecurityAlgorithms.HmacSha512
                //    ));
            }
        }

        public string GenerateToken(Customer customer) {
            JwtSecurityToken securityToken = new JwtSecurityToken(
                    Header,
                    new JwtPayload(
                        issuer: "MoviesRentalApi",              // qui genere le token
                        audience: null,                         // a qui il est destiné 
                        claims: new Claim[] {                   // donnee suppl. qu'on peut rajouter
                            new Claim("Id", customer.Id.ToString()),
                            new Claim("CustomerFN", customer.FirstName),
                            new Claim("CustomerLN", customer.LastName)
                        },
                        notBefore: DateTime.Now,                // validité : now
                        expires: DateTime.Now.AddDays(1)        // à +1 jour(s)
                    )
                ); 

            return "Bearer " + Handler.WriteToken(securityToken);   // ecrire le token sur base du security token généré
                                                                    // bearer ==> specifier dans l'entete de la requete :
                                                                    //  - le type de l'authentification
                                                                    //  - selection de la bonne authentification a test ( ??? )
        }

        /*
         * Methode pour verifier le token ==> renvoie un customer
         */
        public Customer VerifyToken(string token)
        {
            if (token.StartsWith("Bearer "))
                token = token.Replace("Bearer ", "");

            Customer customer = null;
            JwtSecurityToken securityToken = new JwtSecurityToken(token);

            if (securityToken.ValidFrom <= DateTime.Now && securityToken.ValidTo >= DateTime.Now) {
                JwtPayload payLoad = securityToken.Payload;
                string test = Handler.WriteToken(new JwtSecurityToken(Header, payLoad));

                if (token == test) {
                    // ici je pourrais ajouter une info si le customer est banni ou pas

                    payLoad.TryGetValue("Id", out object id);
                    payLoad.TryGetValue("CustomerFN", out object firstName);
                    payLoad.TryGetValue("CustomerLN", out object lastName);

                    customer = new Customer()
                    {
                        Id = int.Parse((string)id),
                        LastName = (string)lastName,
                        FirstName = (string)firstName
                    };
                }
            }

            return customer;
        }
    }
}
