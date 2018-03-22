export class AuthenticatedModel
{
	constructor(public userId: number, public roles: Array<number>)
	{
		this.roles = new Array<number>();
	}
}