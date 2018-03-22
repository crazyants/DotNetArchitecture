import { Injectable } from "@angular/core";

@Injectable()
export class ValidationService
{
	date_ddmmyyyy = /^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))) ?((20|21|22|23|[01]\d|\d)(([:.][0-5]\d){1,2}))?$/;
	decimal = /^((-?[1-9]+)|[0-9]+)(\.?|\,?)([0-9]*)$/;
	email = /^([a-z0-9_\.\-]{3,})@([\da-z\.\-]{3,})\.([a-z\.]{2,6})$/;
	hex = /^#?([a-f0-9]{6}|[a-f0-9]{3})$/;
	integer = /^-?[0-9]+$/;
	only_zeros = /^0+$/;
	time_hhmm = /^(20|21|22|23|[01]\d|\d)(([:.][0-5]\d){1,2})$/;
	url = /^(https?:\/\/(?:www\.|(?!www))[^\s\.]+\.[^\s]{2,}|www\.[^\s]+\.[^\s]{2,})$/;

	isDate(value) { return this.date_ddmmyyyy.test(value); }
	isDecimal(value) { return this.decimal.test(value); }
	isEmail(value) { return this.email.test(value); }
	isEmpty(value) { return !value || value.toString().trim() === ""; }
	isHex(value) { return this.hex.test(value); }
	isInteger(value) { return this.integer.test(value); }
	isMax(value, max) { return (!value || !max) || (value && max && parseFloat(value) <= parseFloat(max)); }
	isMin(value, min) { return (!value || !min) || (value && min && parseFloat(value) >= parseFloat(min)); }
	isOnlyZeros(value) { return this.only_zeros.test(value); }
	isTime(value) { return this.time_hhmm.test(value); }
	isUrl(value) { return this.url.test(value); }
}