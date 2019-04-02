select user_id as Id,
	   user_login as Login,
	   user_hash as Hash,
	   user_name as Name,
	   user_surname as Surname,
	   user_height as Height,
	   user_weight as Weight,
	   user_age as Age,
	   user_gender_type_id as GenderId,
	   user_type_id as TypeId,
	   entity_id as EntityId
from users
where user_login = @login