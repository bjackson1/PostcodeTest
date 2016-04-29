using System;
using System.Text.RegularExpressions;

namespace PostcodeValidator
{
	public class Postcode
	{
		private string postcode;

		public Postcode (string postcode)
		{
			this.postcode = postcode;
		}

		public bool Validate()
		{
			Regex regex = new Regex (@"(GIR\s0AA) |
				^(
					# A9 or A99 prefix
					( ([A-PR-UWYZ][0-9][0-9]?) |

						# AA99 prefix with some excluded areas
						(([A-PR-UWYZ][A-HK-Y][0-9](?<!(BR|FY|HA|HD|HG|HR|HS|HX|JE|LD|SM|SR|WC|WN|ZE)[0-9])[0-9]) |

							# AA9 prefix with some excluded areas
							([A-PR-UWYZ][A-HK-Y](?<!AB|LL|SO)[0-9]) |

							# WC1A prefix
							(WC[0-9][A-Z]) |
							(

								# A9A prefix
								([A-PR-UWYZ][0-9][A-HJKPSTUW]) |

								# AA9A prefix
								([A-PR-UWYZ][A-HK-Y][0-9][ABEHMNPRVWXY])
							)
						)
					)

					# 9AA suffix
					\s[0-9][ABD-HJLNP-UW-Z]{2}
				)", RegexOptions.IgnorePatternWhitespace);

			return regex.IsMatch(this.postcode);
		}
	}
}


